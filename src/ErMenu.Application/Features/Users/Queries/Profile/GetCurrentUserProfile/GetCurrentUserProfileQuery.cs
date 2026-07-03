using ErMenu.Application.Common.DTOs.Users;
using ErMenu.Application.Common.Models.BaseResult;
using MediatR;

namespace ErMenu.Application.Features.Users.Queries.Profile.GetCurrentUserProfile;

public record GetCurrentUserProfileQuery : IRequest<Result<UserProfileDto>>;