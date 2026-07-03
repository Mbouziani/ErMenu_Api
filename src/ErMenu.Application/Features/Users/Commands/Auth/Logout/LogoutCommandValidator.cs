using FluentValidation;
using ErMenu.Domain.Aggregates.Users.Exceptions;

namespace ErMenu.Application.Features.Users.Commands.Auth.Logout;

internal class LogoutCommandValidator : AbstractValidator<LogoutCommand>
{
    public LogoutCommandValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithMessage("Refresh token is required")
            .WithErrorCode(UserErrorCodes.RefreshTokenRequired);
    }
}