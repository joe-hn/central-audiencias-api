using Anuncio.Infrastructure.IRepositories;
using Anuncio.Service.EventHandler.command;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Anuncio.Service.EventHandler.eventHandler
{
    public class AnuncioDeleteEventHandler : INotificationHandler<AnuncioDeleteCommand>
    {
        private readonly IAvisoRepository avisoRepository;        

        public AnuncioDeleteEventHandler(IAvisoRepository anuncioRepository)
        {
            this.avisoRepository = anuncioRepository;            
        }

        public async Task Handle(AnuncioDeleteCommand notification, CancellationToken cancellationToken)
        {
            await this.avisoRepository.DeleteAsync(notification.id);
        }
    }
}
