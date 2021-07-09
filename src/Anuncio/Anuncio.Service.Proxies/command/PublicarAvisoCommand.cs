using System;
using System.ComponentModel.DataAnnotations;

namespace Anuncio.Service.Proxies.command
{
    public class PublicarAvisoCommand
    {
        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        public Guid avisoId { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "La propiedad {0} debe tener {1} caracteres máximo y {2} de mínimo")]
        [DataType(DataType.Text)]
        public string titulo { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "La propiedad {0} debe tener {1} caracteres máximo y {2} de mínimo")]
        [DataType(DataType.Text)]
        public string url { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        public int duracion { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "La propiedad {0} debe tener {1} caracteres máximo y {2} de mínimo")]
        [DataType(DataType.Text)]
        public string tipoVideo { get; set; }
    }
}
