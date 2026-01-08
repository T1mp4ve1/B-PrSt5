using Microsoft.AspNetCore.Identity;

namespace Hotel.Services
{
    public interface ILoginService
    {
        Task<SignInResult> LoginAsync(string email, string password, bool rememberMe);
        Task LogoutAsync();
    }
}
