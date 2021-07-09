using SEJE.CORE.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anuncio.Infrastructure.Entities
{
    public class Aviso: IEntityGuid<string>
    {
        public Guid Id { get; set; }

        public string titulo { get; set; }
        public string tipoArchivo { get; set; }

        public string tipoAviso { get; set; }

        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinalizacion { get; set; }

        public string fechaInicioDescripcion { get; set; }
        public string fechaFinalizacionDescripcion { get; set; }

        public string nombreArchivo { get; set; }
        public int duracion { get; set; }
        public string url { get; set; }

        public bool publicado { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool Removed { get; set; }
        
    }
}
