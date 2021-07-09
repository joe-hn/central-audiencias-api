using ListaReproduccionAviso.Infrastructure.Entities;
using ListaReproduccionAviso.Infrastructure.IRepositories;
using ListaReproduccionAviso.Service.EventHandler.command;
using ListaReproduccionAviso.Service.Proxies.IProxies;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ListaReproduccionAviso.Service.EventHandler.eventHandler
{
    public class AvisoCreateListEventHandler : INotificationHandler<AvisoCreateListCommand>
    {

        private readonly IAvisoRepository repository;
        private readonly IAnuncioProxy anuncioProxy;

        public AvisoCreateListEventHandler(IAvisoRepository repository, IAnuncioProxy anuncioProxy)
        {
            this.repository = repository;
            this.anuncioProxy = anuncioProxy;
        }


        public async Task Handle(AvisoCreateListCommand notification, CancellationToken cancellationToken)
        {
            await this.repository.TransactionAsync<bool>(async ct => 
            {
                await this.repository.DeleteRangeAsync(await this.repository.GetEntity<Aviso>().ToListAsync());

                var data = JsonConvert.DeserializeObject<List<AnuncionCommand>>(await this.anuncioProxy.ListaAnunciosDiarios(notification.FechaActual));

                List<Aviso> avisos = new List<Aviso>();

                foreach (AnuncionCommand item in data)
                {
                    avisos.Add(new Aviso
                    {
                        avisoId = item.AvisoId,
                        titulo = item.Titulo,
                        url = item.Url,
                        duracion = item.Duracion,
                        tipoVideo = item.TipoArchivoFormato
                    });
                }

                await this.repository.CreateRangeAsync(avisos);

                return true;
            });            
        }
    }

    public class AnuncionCommand
    {
        public Guid AvisoId { get; set; }
        public Guid ArchivoId { get; set; }

        public string Titulo { get; set; }
        public string TipoArchivo { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }

        public string Url { get; set; }
        public string TipoArchivoFormato { get; set; }
        public int Duracion { get; set; }
        public string Nombre { get; set; }
        public Guid Id { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool Removed { get; set; }
    }
}
