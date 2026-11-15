using ErMenu.Application.Common.Behaviors;
using ErMenu.Application.Common.DTOs.Auth;
using ErMenu.Application.Common.Interfaces;
using ErMenu.Application.Common.Interfaces.Security;
using ErMenu.Application.Common.Models.BaseResult; 
using ErMenu.Domain.Aggregates.Users.Entities; 
using ErMenu.Domain.Aggregates.Users.Exceptions;
using ErMenu.Domain.Aggregates.Users.Repositories;
using MediatR; 

namespace ErMenu.Application.Features.Users.Commands.Auth.Login;

internal class LoginCommandHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    IRefreshTokenRepository refreshTokenRepository,
    IPasswordService passwordService,
    IJwtTokenService jwtTokenService)
    : IRequestHandler<LoginCommand, Result<TokenDto>> 
{
    public async Task<Result<TokenDto>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {

        var user = await userRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw UserExceptions.InvalidLoginCredentials();

        var isValid = passwordService.Verify(request.Password, user.PasswordHash);

        if (!isValid)
            throw UserExceptions.InvalidLoginCredentials(); 


        var tokens = jwtTokenService.GenerateLoginTokens(user);

        var hashedRefreshToken = jwtTokenService.Hash(tokens.RefreshToken);

        var session =  new RefreshToken(
            user.Id,
            hashedRefreshToken,
            tokens.RefreshTokenExpiresAt);

        await refreshTokenRepository.AddAsync(session, cancellationToken); 

        await unitOfWork.SaveChangesAsync(cancellationToken);


        return Result<TokenDto>.Success(tokens);
    }
}
