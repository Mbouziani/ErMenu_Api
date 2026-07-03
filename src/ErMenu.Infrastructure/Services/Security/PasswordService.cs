using ErMenu.Application.Common.Interfaces.Security;

namespace ErMenu.Infrastructure.Services.Security;

public class PasswordService : IPasswordService
{ 
     
    public bool Verify(string password, string passwordHash)
    {
        return password == passwordHash;
    }
}