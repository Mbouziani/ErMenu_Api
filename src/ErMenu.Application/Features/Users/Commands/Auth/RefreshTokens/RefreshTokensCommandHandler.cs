using MediatR;
using ErMenu.Application.Common.DTOs.Auth; 
using ErMenu.Application.Common.Interfaces;
using ErMenu.Application.Common.Interfaces.Security;
using ErMenu.Application.Common.Models.BaseResult; 
using ErMenu.Domain.Aggregates.Users.Entities;
using ErMenu.Domain.Aggregates.Users.Exceptions;
using ErMenu.Domain.Aggregates.Users.Repositories;

namespace ErMenu.Application.Features.Users.Commands.Auth.RefreshTokens;

internal class RefreshTokensCommandHandler(
    IUnitOfWork unitOfWork,
    IRefreshTokenRepository refreshTokenRepository,
    IJwtTokenService jwtTokenService)
    : IRequestHandler<RefreshTokensCommand, Result<TokenDto>>
{
    public async Task<Result<TokenDto>> Handle(
        RefreshTokensCommand request,
        CancellationToken cancellationToken)
    {
        var hashedRefreshToken = jwtTokenService.Hash(request.RefreshToken);

        var session = await refreshTokenRepository
            .GetByRefreshTokenIncludedUserAsync(hashedRefreshToken, cancellationToken)
            ?? throw UserExceptions.RefreshTokenMissing();

        if (!session.IsActive)
            throw UserExceptions.TokenInvalid(); 
         
        session.Revoke(); 

        var newTokens = jwtTokenService.GenerateLoginTokens(session.User);

        var newHashedRefreshToken = jwtTokenService.Hash(newTokens.RefreshToken);

        var newSession = new RefreshToken(
            session.User.Id,
            newHashedRefreshToken,
            newTokens.RefreshTokenExpiresAt);

        await refreshTokenRepository.AddAsync(newSession, cancellationToken); 

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<TokenDto>.Success(newTokens);
    }
}