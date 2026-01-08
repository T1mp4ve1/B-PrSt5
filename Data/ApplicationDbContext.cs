using Hotel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class ApplicationDbContext : IdentityDbContext<ClienteModel, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CameraModel> Camere { get; set; }
        public DbSet<PrenotazioneModel> Prenotazioni { get; set; }
        public DbSet<TipoCamera> TipiCamere { get; set; }
    }
}