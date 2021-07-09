using MediatR;
using System;
using System.Collections.Generic;

namespace ListaReproduccionAviso.Service.EventHandler.command
{
    public class AvisoCreateListCommand: INotification
    {
        public DateTime FechaActual { get; set; }
    }

    
}
