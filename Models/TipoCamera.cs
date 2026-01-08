using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class TipoCamera
    {
        [Key]
        [Required]
        public int TipoCameraId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; }

        [Required]
        [Precision(10, 2)]
        public decimal Prezzo { get; set; }

        public ICollection<CameraModel> Camere { get; set; }
    }
}
