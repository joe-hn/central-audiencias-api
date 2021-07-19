using ListaReproduccionAudiencia.Service.EventHandler.command;
using ListaReproduccionAudiencia.Service.Queries.IQueries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ListaReproduccionAudiencia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ListaReproduccionAudienciasController : Controller
    {
        private readonly IAudienciaQueryService queryAudiencia;
        private readonly IParteQueryService queryParte;
        private readonly IMediator mediator;

        public ListaReproduccionAudienciasController(IAudienciaQueryService queryAudiencia, IParteQueryService queryParte, IMediator mediator)
        {
            this.queryAudiencia = queryAudiencia;
            this.queryParte = queryParte;
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CrearListaReproduccion(AudienciaCreateListCommand notificacion)
        {
            await this.mediator.Publish(notificacion);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> BorrarListaReproduccion(AudienciaDeleteListCommand notificion)
        {
            await this.mediator.Publish(notificion);
            return Ok();
        }       

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAudiencia()
        {
            var data = await this.queryAudiencia.GetAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("[action]/{audienciaId}")]
        public async Task<IActionResult> GetPartes(Guid audienciaId)
        {
            var data = await this.queryParte.GetAudienciaIdAsync(audienciaId);
            return Ok(data);
        }       

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPartes()
        {
            var data = await this.queryParte.GetParteAsync();
            return Ok(data);
        }

    }
}
