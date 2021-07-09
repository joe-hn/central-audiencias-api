using System;

namespace ListaReproduccionAviso.Service.Proxies.command
{
    public class AnuncionCommand
    {
        public Guid AvisoId { get; set; }
        public Guid ArchivoId { get; set; }

        public string Titulo { get; set; }
        public string TipoArchivo { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }

        public string Url { get; set; }
        public string TipoArchivoFormato { get; set; }
        public int Duracion { get; set; }
        public string Nombre { get; set; }
        public Guid Id { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool Removed { get; set; }
    }
}
