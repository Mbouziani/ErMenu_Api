using ErMenu.Application.Common.DTOs.Auth;
using ErMenu.Application.Common.Models.BaseResult;
using MediatR;

namespace ErMenu.Application.Features.Users.Commands.Auth.RefreshTokens;

public sealed record RefreshTokensCommand(string RefreshToken) : IRequest<Result<TokenDto>>;