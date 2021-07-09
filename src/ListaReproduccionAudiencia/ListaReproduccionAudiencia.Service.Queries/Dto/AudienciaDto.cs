using SEJE.CORE.Abstractions;
using System;

namespace ListaReproduccionAudiencia.Service.Queries.Dto
{
    public class AudienciaDto: IDtoGuid<string>
    {
        public Guid Id { get; set; }

        public string NumeroAudiencia { get; set; }
        public string TipoAudiencia { get; set; }
        public string Despacho { get; set; }
        public string Hora { get; set; }
        public string NumeroExpediente { get; set; }
        public string EstadoAudiencia { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool Removed { get; set; }


    }
}
