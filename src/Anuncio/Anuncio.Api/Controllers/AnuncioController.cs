using Anuncio.Service.EventHandler.command;
using Anuncio.Service.Queries.IQueries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Anuncio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AnuncioController : Controller
    {
        private readonly IMediator mediator;
        private readonly IAnuncioQueryService query;

        public AnuncioController(IMediator mediator, IAnuncioQueryService query)
        {
            this.query = query;
            this.mediator = mediator;
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
            await this.mediator.Publish(notification);
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> AnuncioDelete(AnuncioDeleteCommand notification)
        {
            await this.mediator.Publish(notification);
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> AnuncioUpdate(AnuncioUpdateCommand notification)
        {
            await this.mediator.Publish(notification);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> PublicarAnuncio(AnuncioPublicarCommand notification)
        {
            await this.mediator.Publish(notification);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DespublicarAnuncio(AnuncioDespublicarCommand notification)
        {
            await this.mediator.Publish(notification);
            return Ok();
        }
    }
}