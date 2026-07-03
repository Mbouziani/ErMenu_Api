namespace ErMenu.Domain.Common.Exceptions.Base;

public class NotFoundException(
    string code,
    string message)
    : DomainException(code, message);