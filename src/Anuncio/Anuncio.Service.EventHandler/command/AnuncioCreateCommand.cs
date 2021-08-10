using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Anuncio.Service.EventHandler.command
{
    public class AnuncioCreateCommand: INotification
    {        
        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "La propiedad {0} debe tener {1} caracteres máximo y {2} de mínimo")]
        [DataType(DataType.Text)]
        public string titulo { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "La propiedad {0} debe tener {1} caracteres máximo y {2} de mínimo")]
        [DataType(DataType.Text)]
        public string tipoArchivo { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "La propiedad {0} debe tener {1} caracteres máximo y {2} de mínimo")]
        [DataType(DataType.Text)]
        public string tipoAviso { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        public DateTime fechaInicio { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        public DateTime fechaFinalizacion { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "La propiedad {0} debe tener {1} caracteres máximo y {2} de mínimo")]
        [DataType(DataType.Text)]
        public string nombreArchivo { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        public int duracion { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        public string file { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "La propiedad {0} debe tener {1} caracteres máximo y {2} de mínimo")]
        [DataType(DataType.Text)]
        public string url { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        public bool publicado { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        public string formatoArchivo { get; set; }

    }
   
}
