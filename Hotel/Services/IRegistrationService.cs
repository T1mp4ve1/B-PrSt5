using Hotel.Models;
using Microsoft.AspNetCore.Identity;

namespace Hotel.Services
{
    public interface IRegistrationService
    {
        Task<IdentityResult> CreateUserAsync(RegistrationModel model);
        Task<List<ClienteModel>> GetAllAsync();
    }
}
