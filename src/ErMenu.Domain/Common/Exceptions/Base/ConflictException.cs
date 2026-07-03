namespace ErMenu.Domain.Common.Exceptions.Base;

public class ConflictException(
    string code,
    string message)
    : DomainException(code, message);