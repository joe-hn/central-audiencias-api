using System.ComponentModel.DataAnnotations;

namespace SEJE.EFCORE.Options
{
    public class EFCoreOption
    {
        [Required]
        public ClaimsOption ClaimsIdentity { get; set; }
    }
}
