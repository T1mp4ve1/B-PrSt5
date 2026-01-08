using Hotel.Models;
using Microsoft.AspNetCore.Identity;

namespace Hotel.Services
{
    public interface IRegistrationService
    {
        Task<IdentityResult> CreateUserAsync(RegistrationModel model);
        Task<IdentityResult> CreateAdminAsync(RegistrationModel model);
        Task<IList<string>> GetRolesAsync(ClienteModel user);
        Task<List<ClienteModel>> GetAllAsync();
        Task<IdentityResult> DeleteUserAsync(string userId);
        Task<IdentityResult> UpdateUserAsync(ClienteModel updatedUser);
    }
}