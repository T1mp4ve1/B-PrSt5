using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class CameraModel
    {
        [Key]
        [Required]
        public int CameraId { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; }

        [Required]
        [Precision(10, 2)]
        public decimal Prezzo { get; set; }

        public ICollection<PrenotazioneModel> Prenotazioni { get; set; }
    }
}
