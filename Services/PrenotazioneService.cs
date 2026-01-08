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

        //
        public async Task<PrenotazioneModel?> GetByIdAsync(Guid id)
        {
            return await _db.Prenotazioni
                .Include(p => p.Cliente)
                .Include(p => p.Camera)
                .FirstOrDefaultAsync(p => p.PrenotazioneId == id);
        }

        public async Task UpdateAsync(PrenotazioneModel prenotazione)
        {
            var existing = await _db.Prenotazioni.FindAsync(prenotazione.PrenotazioneId);
            if (existing != null)
            {
                existing.DataInizio = prenotazione.DataInizio;
                existing.DataFine = prenotazione.DataFine;
                existing.Stato = prenotazione.Stato;
                existing.CameraId = prenotazione.CameraId;

                _db.Prenotazioni.Update(existing);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var prenotazione = await _db.Prenotazioni.FindAsync(id);
            if (prenotazione != null)
            {
                _db.Prenotazioni.Remove(prenotazione);
                await _db.SaveChangesAsync();
            }
        }
    }
}