using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anuncio.Service.EventHandler.command
{
    public class AnuncioDeleteCommand: INotification
    {
        [Required(ErrorMessage = "La propiedad {0} es obligatorio")]
        public Guid id { get; set; }
        
    }
}
