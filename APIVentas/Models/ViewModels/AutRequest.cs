using System.ComponentModel.DataAnnotations;

namespace APIVentas.Models.ViewModels
{
    public class AutRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
