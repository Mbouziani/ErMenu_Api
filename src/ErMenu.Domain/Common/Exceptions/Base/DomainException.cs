namespace ErMenu.Domain.Common.Exceptions.Base;

 
public abstract class DomainException(string code, string message) : Exception(message)
{
    public string ErrorCode { get; } = code;
}