namespace ErMenu.Domain.Common.Exceptions.Base;

public class UnauthorizedException(
    string code,
    string message)
    : DomainException(code, message);