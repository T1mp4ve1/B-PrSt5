using Hotel.Models;

namespace Hotel.Services
{
    public interface IPrenotazioneService
    {
        Task CreateAsync(PrenotazioneModel prenotazione);
        Task<List<PrenotazioneModel>> GetAllAsync();
        Task<PrenotazioneModel?> GetByIdAsync(Guid id);
        Task UpdateAsync(PrenotazioneModel prenotazione);
        Task DeleteAsync(Guid id);
    }
}