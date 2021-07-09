
using ListaReproduccionAviso.Infrastructure.Entities;
using ListaReproduccionAviso.Infrastructure.IRepositories;
using ListaReproduccionAviso.Service.EventHandler.command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ListaReproduccionAviso.Service.EventHandler.eventHandler
{
    public class PublicarAvisoEventHandler : INotificationHandler<PublicarAvisoCommand>
    {
        private readonly IAvisoRepository repository;
        public PublicarAvisoEventHandler(IAvisoRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(PublicarAvisoCommand notification, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new Aviso {
                avisoId = notification.avisoId,
                duracion = notification.duracion,
               tipoVideo = notification.tipoVideo,
                titulo = notification.titulo,
                url = notification.url
            });
        }
    }
}
