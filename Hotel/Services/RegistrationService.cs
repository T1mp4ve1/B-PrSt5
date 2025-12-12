using Hotel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<ClienteModel> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegistrationService(UserManager<ClienteModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateUserAsync(RegistrationModel model)
        {
            var user = new ClienteModel
            {
                UserName = model.Email,
                Email = model.Email,
                Nome = model.Nome,
                Cognome = model.Cognome,
                PhoneNumber = model.Telefono,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false
            };

            var res = await _userManager.CreateAsync(user, model.Password);

            if (res.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(model.Ruolo))
                {
                    await _roleManager.CreateAsync(new IdentityRole(model.Ruolo));
                }

                await _userManager.AddToRoleAsync(user, model.Ruolo);
            }
            return res;
        }

        public async Task<IList<string>> GetRolesAsync(ClienteModel user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<List<ClienteModel>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
