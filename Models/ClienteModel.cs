using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class ClienteModel : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(200)]
        public string Cognome { get; set; }

        public ICollection<PrenotazioneModel> Prenotazioni { get; set; }
    }
}
