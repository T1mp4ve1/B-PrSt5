using Hotel.Models;

namespace Hotel.Services
{
    public interface IPrenotazioneService
    {
        Task CreateAsync(PrenotazioneModel prenotazione);
        Task<List<PrenotazioneModel>> GetAllAsync();
    }
}