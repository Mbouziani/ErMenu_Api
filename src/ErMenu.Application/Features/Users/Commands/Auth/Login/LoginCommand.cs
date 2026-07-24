using ErMenu.Application.Common.DTOs.Auth;
using ErMenu.Application.Common.Models.BaseResult;
using MediatR;

namespace ErMenu.Application.Features.Users.Commands.Auth.Login;

public sealed record LoginCommand(int Id, string Password) 
    : IRequest<Result<TokenDto>>; 