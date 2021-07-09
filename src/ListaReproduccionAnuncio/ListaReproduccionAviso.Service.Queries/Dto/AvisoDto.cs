using SEJE.CORE.Abstractions;
using System;

namespace ListaReproduccionAviso.Service.Queries.Dto
{
    public class AvisoDto: IDtoGuid<string>
    {
        public Guid Id { get; set; }

        public Guid AvisoId { get; set; }
        public string Titulo { get; set; }

        public string Url { get; set; }
        public int Duracion { get; set; }
        public string TipoVideo { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool Removed { get; set; }
    }
}
