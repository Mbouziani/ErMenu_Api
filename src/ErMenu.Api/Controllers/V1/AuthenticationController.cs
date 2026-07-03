using Asp.Versioning;
using ErMenu.Application.Features.Users.Commands.Auth.Login;
using ErMenu.Application.Features.Users.Commands.Auth.Logout;
using ErMenu.Application.Features.Users.Commands.Auth.RefreshTokens;
using ErMenu.Application.Features.Users.Queries.Profile.GetCurrentUserProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErMenu.Api.Controllers.V1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]

public class AuthenticationController(ISender sender) : ControllerBase
{
    [HttpGet("profile-info")]
    public async Task<IActionResult> GetProfile()
      => Ok(await sender.Send(new GetCurrentUserProfileQuery()));

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginCommand request)
        => Ok(await sender.Send(request));

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutCommand request)
        => Ok(await sender.Send(request));

    [HttpPost("refresh-token")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokensCommand request)
        => Ok(await sender.Send(request));   
}
