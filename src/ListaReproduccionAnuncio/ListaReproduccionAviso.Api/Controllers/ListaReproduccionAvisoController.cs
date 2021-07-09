using ListaReproduccionAviso.Service.EventHandler.command;
using ListaReproduccionAviso.Service.Queries.IQueries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ListaReproduccionAviso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ListaReproduccionAvisoController : Controller
    {
        private readonly IAvisoQueryService query;
        private readonly IMediator mediator;

        public ListaReproduccionAvisoController(IAvisoQueryService query, IMediator mediator)
        {
            this.query = query;
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> PublicarAviso(PublicarAvisoCommand notification)
        {
            await mediator.Publish(notification);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CrearListaReproduccion(AvisoCreateListCommand notification)
        {
            await mediator.Publish(notification);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> EliminarListaReproduccion(AvisoDeleteListCommand notification)
        {
            await mediator.Publish(notification);
            return Ok();
        }


        [HttpGet]
        [Route("[action]/{CurrentPage}/{PageSize}")]
        public async Task<IActionResult> Page(int CurrentPage, int PageSize)
        {
            var data = await this.query.PageAsync(CurrentPage, PageSize);
            return Ok(data);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            var data = await this.query.GetAllAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var data = await this.query.GetIdAsync(id);
            return Ok(data);
        }
        
    }
}
