using FluentValidation;
using ErMenu.Domain.Aggregates.Users.Exceptions;

namespace ErMenu.Application.Features.Users.Commands.Auth.RefreshTokens;

internal class RefreshTokensCommandValidator : AbstractValidator<RefreshTokensCommand>
{
    public RefreshTokensCommandValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithMessage("Refresh token is required")
            .WithErrorCode(UserErrorCodes.RefreshTokenRequired);
    }
}