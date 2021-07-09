using System;

namespace ListaReproduccionAudiencia.Service.Proxies.command
{
    public class ParteCommand
    {
        public Guid ParteId { get; set; }
        public Guid AudienciaId { get; set; }
        public string Nombre { get; set; }
        public string TipoParte { get; set; }
        public string TipoPersona { get; set; }
    }
}
