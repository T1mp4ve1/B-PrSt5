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
        public int TipoCameraId { get; set; }
        public TipoCamera TipoCamera { get; set; }

        public ICollection<PrenotazioneModel> Prenotazioni { get; set; }
    }
}
