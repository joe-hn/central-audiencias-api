using ListaReproduccionAviso.Infrastructure.Entities;
using ListaReproduccionAviso.Infrastructure.IRepositories;
using ListaReproduccionAviso.Service.EventHandler.command;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ListaReproduccionAviso.Service.EventHandler.eventHandler
{
    public class AvisoDeleteListEventHandler : INotificationHandler<AvisoDeleteListCommand>
    {

        private readonly IAvisoRepository repository;

        public AvisoDeleteListEventHandler(IAvisoRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(AvisoDeleteListCommand notification, CancellationToken cancellationToken)
        {            
            await this.repository.DeleteRangeAsync(await this.repository.GetEntity<Aviso>().ToListAsync());
        }
    }


}
