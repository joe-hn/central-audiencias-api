using System.ComponentModel.DataAnnotations;

namespace SEJE.EFCORE.Options
{
    public class ClaimsOption
    {
        [Required]
        public string User { get; set; }

        [Required]
        public string IdUser { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
