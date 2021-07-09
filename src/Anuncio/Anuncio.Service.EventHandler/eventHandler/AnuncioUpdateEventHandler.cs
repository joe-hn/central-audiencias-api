using Anuncio.Infrastructure.Entities;
using Anuncio.Infrastructure.IRepositories;
using Anuncio.Service.EventHandler.command;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Anuncio.Service.EventHandler.eventHandler
{
    public class AnuncioUpdateEventHandler : INotificationHandler<AnuncioUpdateCommand>
    {
        private readonly IAvisoRepository avisoRepository;        

        public AnuncioUpdateEventHandler(IAvisoRepository avisoRepository)
        {
            this.avisoRepository = avisoRepository;            
        }

        public async Task Handle(AnuncioUpdateCommand notification, CancellationToken cancellationToken)
        {
            await this.avisoRepository.UpdateAsync(notification.id, new Aviso 
            {
                tipoArchivo = notification.tipoArchivo,
                tipoAviso = notification.tipoAviso,
                nombreArchivo = notification.nombreArchivo,
                duracion = notification.duracion,
                fechaFinalizacion = notification.fechaFinalizacion,
                fechaInicio = notification.fechaInicio,
                url = notification.url,
                titulo = notification.titulo,
                fechaInicioDescripcion = notification.fechaInicio.ToString("dd/MM/yyyy"),
                fechaFinalizacionDescripcion = notification.fechaFinalizacion.ToString("dd/MM/yyyy"),
                publicado = notification.publicado
            });          
        }
    }
}
