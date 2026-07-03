using ErMenu.Application.Common.Models.BaseResult;
using MediatR;

namespace ErMenu.Application.Features.Users.Commands.Auth.Logout;

public sealed record LogoutCommand(string RefreshToken) : IRequest<Result<bool>>;