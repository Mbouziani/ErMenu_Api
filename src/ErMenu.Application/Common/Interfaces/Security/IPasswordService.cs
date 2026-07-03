namespace ErMenu.Application.Common.Interfaces.Security;

public interface IPasswordService
{
     bool Verify(string password, string passwordHash);
 }