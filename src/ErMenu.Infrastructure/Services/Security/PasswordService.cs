using ErMenu.Application.Common.Interfaces.Security;
using System.Text;

namespace ErMenu.Infrastructure.Services.Security;

public class PasswordService : IPasswordService
{ 
     
    public bool Verify(string password, string passwordHash)
    {
        var hashedPassword = HashSHA1(password);
        return hashedPassword.Equals(passwordHash);
    }

    public static string HashSHA1(string value)
    {

        var sha1 = System.Security.Cryptography.SHA1.Create();
        var inputBytes = Encoding.ASCII.GetBytes(value);
        var hash = sha1.ComputeHash(inputBytes);
        var sb = new StringBuilder();
        for (var i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
}