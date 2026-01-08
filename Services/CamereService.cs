using Hotel.Data;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services
{
    public class CamereService : ICamereService
    {
        private readonly ApplicationDbContext _db;
        public CamereService(ApplicationDbContext db) { _db = db; }

        //tipi
        public async Task TypeCreateAsync(TipoCamera tipo)
        {
            _db.TipiCamere.Add(tipo);
            await _db.SaveChangesAsync();
        }

        public async Task<List<TipoCamera>> TypeGetAllAsync()
        {
            return await _db.TipiCamere.AsNoTracking().ToListAsync();
        }

        //camere
        public async Task CreateAsync(CameraModel camera)
        {
            _db.Camere.Add(camera);
            await _db.SaveChangesAsync();
        }

        public async Task<List<CameraModel>> GetAllAsync()
        {
            return await _db.Camere.AsNoTracking().ToListAsync();
        }
    }
}
