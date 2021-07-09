using ListaReproduccionAudiencia.Infrastructure.Entities;
using ListaReproduccionAudiencia.Infrastructure.IRepositories;
using ListaReproduccionAudiencia.Service.EventHandler.command;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ListaReproduccionAudiencia.Service.EventHandler.eventHandler
{
    public class AudienciaDeleteListEventHandler : INotificationHandler<AudienciaDeleteListCommand>
    {
        private readonly IAudienciaRepository audienciaRepository;
        private readonly IParteRepository parteRepository;

        public AudienciaDeleteListEventHandler(IAudienciaRepository audienciaRepository, IParteRepository parteRepository)
        {
            this.audienciaRepository = audienciaRepository;
            this.parteRepository = parteRepository;
        }

        public async Task Handle(AudienciaDeleteListCommand notification, CancellationToken cancellationToken)
        {
            await this.parteRepository.TransactionAsync<bool>(async ct => 
            {
                await this.parteRepository.DeleteRangeAsync(await this.parteRepository.GetEntity<Parte>().ToListAsync());
                await this.audienciaRepository.DeleteRangeAsync(await this.audienciaRepository.GetEntity<Audiencia>().ToListAsync());

                return true;
            });
        }
    }
   
}
