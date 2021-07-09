using ListaReproduccionAudiencia.Infrastructure.Entities;
using ListaReproduccionAudiencia.Infrastructure.IRepositories;
using ListaReproduccionAudiencia.Service.EventHandler.command;
using ListaReproduccionAudiencia.Service.Proxies.IProxies;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ListaReproduccionAudiencia.Service.EventHandler.eventHandler
{
    public class AudienciaCreateListEventHandler : INotificationHandler<AudienciaCreateListCommand>
    {
        private readonly IAudienciaRepository audienciaRepository;
        private readonly IParteRepository parteRepository;

        public AudienciaCreateListEventHandler(IAudienciaRepository audienciaRepository, IParteRepository parteRepository)
        {
            this.audienciaRepository = audienciaRepository;
            this.parteRepository = parteRepository;            
        }

        public async Task Handle(AudienciaCreateListCommand notification, CancellationToken cancellationToken)
        {
            await this.audienciaRepository.TransactionAsync<bool>(async ct => 
            {

                var audienciaId = await this.audienciaRepository.CreateAsync(new Audiencia 
                {
                    EstadoAudiencia = notification.EstadoAudiencia,
                    NumeroAudiencia = notification.NumeroAudiencia,
                    TipoAudiencia = notification.TipoAudiencia,
                    Despacho = notification.Despacho,
                    Hora = notification.Hora,
                    NumeroExpediente = notification.NumeroExpediente                    
                });

                List<Parte> parte = new List<Parte>();

                foreach (ParteCommand item in notification.Partes)
                {
                    parte.Add(new Parte { 
                        AudienciaId = audienciaId,
                        Nombre = item.Nombre,
                        TipoParte = item.TipoParte,
                        TipoPersona = item.TipoPersona                        
                    });
                }

                await this.parteRepository.CreateRangeAsync(parte);
                
                return true;
            });
        }


        
    }
}
