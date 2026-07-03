using ErMenu.Domain.Aggregates.Users.Exceptions;
using ErMenu.Domain.Common.Exceptions;
using FluentValidation;

namespace ErMenu.Application.Features.Users.Commands.Auth.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {

        RuleFor(x => x.Email)
           .NotEmpty()
           .WithMessage("Email is required")
           .WithErrorCode(CommonErrorCodes.EmailRequired);

        RuleFor(x => x.Email)
          .EmailAddress()
          .WithMessage("Invalid Email Format")
          .WithErrorCode(CommonErrorCodes.InvalidEmailFormat);

        RuleFor(x => x.Password)
           .NotEmpty()
           .WithMessage("Password is required")
           .WithErrorCode(UserErrorCodes.PasswordRequired);
    }
}