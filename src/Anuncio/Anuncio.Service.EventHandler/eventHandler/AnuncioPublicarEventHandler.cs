using Anuncio.Infrastructure.Entities;
using Anuncio.Infrastructure.IRepositories;
using Anuncio.Service.EventHandler.command;
using Anuncio.Service.Proxies.command;
using Anuncio.Service.Proxies.IProxies;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anuncio.Service.EventHandler.eventHandler
{
    public class AnuncioPublicarEventHandler : INotificationHandler<AnuncioPublicarCommand>
    {
        private readonly IAvisoRepository repository;
        private readonly IPublicarProxy publicarProxy;

        public AnuncioPublicarEventHandler(IAvisoRepository repository, IPublicarProxy publicarProxy)
        {
            this.repository = repository;
            this.publicarProxy = publicarProxy;
        }
        public async Task Handle(AnuncioPublicarCommand notification, CancellationToken cancellationToken)
        {
            await this.repository.TransactionAsync<bool>(async ct => 
            {                
                var aviso = this.repository.GetEntity<Aviso>().Where(x => x.Id == notification.id).FirstOrDefault();

                await this.publicarProxy.Publicaraviso(new PublicarAvisoCommand {
                    avisoId = aviso.Id,
                    duracion = aviso.duracion,
                    tipoVideo = aviso.tipoArchivo,
                    titulo = aviso.titulo,
                    url = aviso.url
                });

                aviso.publicado = true;

                await this.repository.UpdateAsync(aviso.Id, aviso);               

                return true;
            });
        }
    }
}
