using Hotel.Data;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services
{
    public class PrenotazioneService : IPrenotazioneService
    {
        private readonly ApplicationDbContext _db;

        public PrenotazioneService(ApplicationDbContext db) { _db = db; }

        public async Task CreateAsync(PrenotazioneModel prenotazione)
        {
            _db.Prenotazioni.Add(prenotazione);
            await _db.SaveChangesAsync();
        }

        public async Task<List<PrenotazioneModel>> GetAllAsync()
        {
            return await _db.Prenotazioni
                .Include(p => p.Cliente)
                .Include(c => c.Camera).AsNoTracking().ToListAsync();
        }
    }
}