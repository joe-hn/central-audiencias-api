using MediatR;
using System;

namespace Anuncio.Service.EventHandler.command
{
    public class AnuncioDespublicarCommand: INotification
    {
        public Guid Id { get; set; }
    }
}
