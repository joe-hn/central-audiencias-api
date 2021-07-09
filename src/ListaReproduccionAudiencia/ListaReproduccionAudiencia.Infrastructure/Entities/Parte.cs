using SEJE.CORE.Abstractions;
using System;

namespace ListaReproduccionAudiencia.Infrastructure.Entities
{
    public class Parte: IEntityGuid<string>
    {
        public Guid Id { get; set; }

        public Guid AudienciaId { get; set; }
        public string Nombre { get; set; }
        public string TipoParte { get; set; }
        public string TipoPersona { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool Removed { get; set; }

        public Audiencia Audiencia { get; set; }
    }
}
