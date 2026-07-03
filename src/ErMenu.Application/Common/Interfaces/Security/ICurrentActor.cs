namespace ErMenu.Application.Common.Interfaces.Security;

public interface ICurrentActor
{
    int UserId { get; }
    string? Email { get; }
    bool IsAuthenticated { get; }
}