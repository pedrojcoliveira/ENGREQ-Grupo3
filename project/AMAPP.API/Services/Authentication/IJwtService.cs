using AMAPP.API.DTOs.Auth;
using Microsoft.AspNetCore.Identity;

namespace AMAPP.API.Services.Authentication
{
    public interface IJwtService
    {
        LoginResponseDto CreateToken(IdentityUser user);
    }
}
