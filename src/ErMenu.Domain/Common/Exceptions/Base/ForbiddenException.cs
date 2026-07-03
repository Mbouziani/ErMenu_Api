namespace ErMenu.Domain.Common.Exceptions.Base;

public class ForbiddenException(
    string code,
    string message)
    : DomainException(code, message);