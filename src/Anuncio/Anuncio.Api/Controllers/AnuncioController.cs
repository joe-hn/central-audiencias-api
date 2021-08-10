using Anuncio.Service.EventHandler.command;
using Anuncio.Service.Queries.IQueries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using WMPLib;

namespace Anuncio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AnuncioController : Controller
    {
        private readonly IMediator mediator;
        private readonly IAnuncioQueryService query;
        private readonly IWebHostEnvironment hosting;

        public AnuncioController(IMediator mediator, IAnuncioQueryService query, IWebHostEnvironment hosting)
        {
            this.query = query;
            this.mediator = mediator;
            this.hosting = hosting;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetId(Guid id)
        {
            var data = await this.query.GetIdAsync(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Page(int CurrentPage, int PageSize)
        {
            var data = await this.query.PageAsync(CurrentPage, PageSize);
            return Ok(data);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetDate(string year, string month, string day)
        {
            DateTime dateNow = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            var data = await this.query.GetDate(dateNow);
            return Ok(data);
        }
        
        [HttpPost]
        [Route("[action]")]          
        public async Task<IActionResult> AnuncioCreate(AnuncioCreateCommand notification)
        {           
            if(ModelState.IsValid)
            {
                var folderPath = System.IO.Path.Combine(hosting.ContentRootPath, "files");
                string name = Guid.NewGuid() + "." + notification.nombreArchivo;

                notification.nombreArchivo = name;
                notification.url = "/files" + name;
                string path = Path.Combine(folderPath, name);

                System.IO.File.WriteAllBytes(path, Convert.FromBase64String(notification.file));

                await this.mediator.Publish(notification);

                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> AnuncioDelete(AnuncioDeleteCommand notification)
        {
            if(ModelState.IsValid)
            {
                await this.mediator.Publish(notification);
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> AnuncioUpdate(AnuncioUpdateCommand notification)
        {
            if(ModelState.IsValid)
            {
                await this.mediator.Publish(notification);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> PublicarAnuncio(AnuncioPublicarCommand notification)
        {
            if(ModelState.IsValid)
            {
                await this.mediator.Publish(notification);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DespublicarAnuncio(AnuncioDespublicarCommand notification)
        {
            if (ModelState.IsValid)
            {
                await this.mediator.Publish(notification);
                return NoContent();
            }
            return BadRequest();
        }
    }
}