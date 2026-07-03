using ErMenu.Application.Common.DTOs.Auth;
using ErMenu.Domain.Aggregates.Users.Entities;

namespace ErMenu.Application.Common.Interfaces.Security;

public interface IJwtTokenService
{  
    TokenDto GenerateLoginTokens(User user); 

    string GeneratePasswordResetToken();

    string Hash(string token);
}