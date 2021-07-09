using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaReproduccionAudiencia.Service.EventHandler.command
{
    public class AudienciaCreateListCommand : INotification
    {        
        public string NumeroAudiencia { get; set; }
        public string TipoAudiencia { get; set; }
        public string Despacho { get; set; }
        public string Hora { get; set; }
        public string NumeroExpediente { get; set; }
        public string EstadoAudiencia { get; set; }
        public List<ParteCommand> Partes { get; set; }
    }    

    public class ParteCommand
    {        
        public Guid AudienciaId { get; set; }
        public string Nombre { get; set; }
        public string TipoParte { get; set; }
        public string TipoPersona { get; set; }
    }

}
