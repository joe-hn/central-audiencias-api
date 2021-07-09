using SEJE.CORE.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaReproduccionAviso.Infrastructure.Entities
{
    public class Aviso: IEntityGuid<string>
    {
        public Guid Id { get; set; }

        public Guid avisoId { get; set; }
        public string titulo { get; set; }

        public string url { get; set; }
        public int duracion { get; set; }
        public string tipoVideo { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool Removed { get; set; }
    }
}
