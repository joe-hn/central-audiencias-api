using Anuncio.Infrastructure.Entities;
using Anuncio.Infrastructure.IRepositories;
using Anuncio.Service.EventHandler.command;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Anuncio.Service.EventHandler.eventHandler
{
    public class AnuncioCreateEventHandler : INotificationHandler<AnuncioCreateCommand>
    {
        private readonly IAvisoRepository avisoRepository;        

        public AnuncioCreateEventHandler(IAvisoRepository avisoRepository)
        {
            this.avisoRepository = avisoRepository;           
        }
        public async Task Handle(AnuncioCreateCommand notification, CancellationToken cancellationToken)
        {
            await this.avisoRepository.CreateAsync(new Aviso
            {
                nombreArchivo = notification.nombreArchivo,
                titulo = notification.titulo,
                fechaFinalizacion = notification.fechaFinalizacion,
                fechaInicio = notification.fechaInicio,
                duracion = notification.duracion,
                tipoArchivo = notification.tipoArchivo,
                tipoAviso = notification.tipoAviso,
                url = notification.url,
                fechaInicioDescripcion = notification.fechaInicio.ToString("dd/MM/yyyy"),
                fechaFinalizacionDescripcion = notification.fechaFinalizacion.ToString("dd/MM/yyyy"),
                publicado = notification.publicado
            }) ;                        
        }
      
    }
}
