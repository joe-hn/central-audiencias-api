using Anuncio.Infrastructure.Entities;
using Anuncio.Infrastructure.IRepositories;
using Anuncio.Service.EventHandler.command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anuncio.Service.EventHandler.eventHandler
{
    public class AnuncioDespublicarEventHandler : INotificationHandler<AnuncioDespublicarCommand>
    {
        private readonly IAvisoRepository repository;

        public AnuncioDespublicarEventHandler(IAvisoRepository repository)
        {
            this.repository = repository;
        }
        public async Task Handle(AnuncioDespublicarCommand notification, CancellationToken cancellationToken)
        {
            var aviso = this.repository.GetEntity<Aviso>().Where(c => c.Id == notification.Id).FirstOrDefault();

            aviso.publicado = false;
            await this.repository.UpdateAsync(aviso.Id, aviso);
        }
    }
}
