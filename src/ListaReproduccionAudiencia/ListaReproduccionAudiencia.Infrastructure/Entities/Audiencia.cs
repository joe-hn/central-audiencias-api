using SEJE.CORE.Abstractions;
using System;
using System.Collections.Generic;

namespace ListaReproduccionAudiencia.Infrastructure.Entities
{
    public class Audiencia: IEntityGuid<string>
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

        public List<Parte> Partes { get; set; }
    }
}
