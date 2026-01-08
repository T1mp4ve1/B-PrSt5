using Hotel.Models;

namespace Hotel.Services
{
    public interface ICamereService
    {
        //tipi
        Task TypeCreateAsync(TipoCamera tipoCamera);
        Task<List<TipoCamera>> TypeGetAllAsync();

        //camere
        Task CreateAsync(CameraModel camera);
        Task<List<CameraModel>> GetAllAsync();
    }
}