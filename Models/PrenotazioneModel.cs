using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class PrenotazioneModel
    {
        [Key]
        [Required]
        public Guid PrenotazioneId { get; set; }

        [Required]
        public string ClienteId { get; set; }
        public ClienteModel Cliente { get; set; }

        [Required]
        public int CameraId { get; set; }
        public CameraModel Camera { get; set; }

        [Required]
        public DateOnly DataInizio { get; set; }

        [Required]
        public DateOnly DataFine { get; set; }

        [Required]
        public bool Stato { get; set; }
    }
}
