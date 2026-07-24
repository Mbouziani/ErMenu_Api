using ErMenu.Domain.Aggregates.Users.Exceptions;
using ErMenu.Domain.Common.Exceptions;
using FluentValidation;

namespace ErMenu.Application.Features.Users.Commands.Auth.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {

        RuleFor(x => x.Id)
           .NotEmpty()
           .WithMessage("User ID is required")
           .WithErrorCode(UserErrorCodes.UserIdRequired); 

        RuleFor(x => x.Password)
           .NotEmpty()
           .WithMessage("Password is required")
           .WithErrorCode(UserErrorCodes.PasswordRequired);
    }
}