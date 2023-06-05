using ATSIdentity.Models;
using Microsoft.AspNetCore.Identity;

namespace ATSIdentity.Services
{
    public interface IAuthService
    {
        string GenerateTokenString(LoginUser user);
        Task<bool> Login(LoginUser user);
        Task<IdentityResult> RegisterUser(LoginUser user);
    }
}
