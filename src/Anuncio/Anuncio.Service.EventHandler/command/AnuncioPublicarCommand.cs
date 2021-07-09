using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Anuncio.Service.EventHandler.command
{
    public class AnuncioPublicarCommand: INotification
    {
        public Guid id { get; set; }
        
    }
}
