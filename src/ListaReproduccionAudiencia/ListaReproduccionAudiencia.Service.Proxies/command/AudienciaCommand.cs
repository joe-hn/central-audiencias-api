using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaReproduccionAudiencia.Service.Proxies.command
{
    public class AudienciaCommand
    {
        public Guid AudienciaId { get; set; }

        public string NumeroAudiencia { get; set; }
        public string TipoAudiencia { get; set; }
        public string Despacho { get; set; }
        public string Hora { get; set; }
        public string NumeroExpediente { get; set; }
        public string EstadoAudiencia { get; set; }
    }
}
