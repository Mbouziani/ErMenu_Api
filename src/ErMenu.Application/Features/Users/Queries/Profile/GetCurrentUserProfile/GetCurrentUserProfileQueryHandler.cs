using MediatR;
using ErMenu.Application.Common.DTOs.Users;
using ErMenu.Application.Common.Interfaces.Security;
using ErMenu.Application.Common.Mappers;
using ErMenu.Application.Common.Models.BaseResult;
using ErMenu.Domain.Aggregates.Users.Exceptions;
using ErMenu.Domain.Aggregates.Users.Repositories;

namespace ErMenu.Application.Features.Users.Queries.Profile.GetCurrentUserProfile;

internal class GetCurrentUserProfileQueryHandler(
    ICurrentActor currentActor,
    IUserRepository userRepository)
    : IRequestHandler<GetCurrentUserProfileQuery, Result<UserProfileDto>>
{
    public async Task<Result<UserProfileDto>> Handle(
        GetCurrentUserProfileQuery request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(currentActor.UserId, cancellationToken)
            ?? throw UserExceptions.AccountUnavailable();


        var response = UserMapper.ToProfileDto(user);

        return Result<UserProfileDto>.Success(response);
    }
}