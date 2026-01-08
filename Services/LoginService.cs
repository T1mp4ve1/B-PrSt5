using Hotel.Models;
using Microsoft.AspNetCore.Identity;

namespace Hotel.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<ClienteModel> _signInManager;

        public LoginService(SignInManager<ClienteModel> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> LoginAsync(string email, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}