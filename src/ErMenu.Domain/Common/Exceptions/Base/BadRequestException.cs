namespace ErMenu.Domain.Common.Exceptions.Base;

public class BadRequestException(
    string code,
    string message)
    : DomainException(code, message);