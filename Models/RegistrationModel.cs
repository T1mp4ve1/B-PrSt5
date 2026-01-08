using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(200)]
        public string Cognome { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; }

        [Required]
        public string Password { get; set; }

        public string? Ruolo { get; set; }
    }
}