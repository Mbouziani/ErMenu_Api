using MediatR;
using ErMenu.Application.Common.Interfaces;
using ErMenu.Application.Common.Interfaces.Security;
using ErMenu.Application.Common.Models.BaseResult; 
using ErMenu.Domain.Aggregates.Users.Repositories;

namespace ErMenu.Application.Features.Users.Commands.Auth.Logout;

internal class LogoutCommandHandler(
    IUnitOfWork unitOfWork,
    IRefreshTokenRepository refreshTokenRepository,
    IJwtTokenService jwtTokenService)
    : IRequestHandler<LogoutCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(
        LogoutCommand request,
        CancellationToken cancellationToken)
    {
        var hashedRefreshToken = jwtTokenService.Hash(request.RefreshToken);

        var session = await refreshTokenRepository.GetByRefreshTokenAsync(hashedRefreshToken, cancellationToken);

        if (session is null) 
            return Result<bool>.Success(true);
        
        session.Revoke(); 

        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result<bool>.Success(true);
    }
}