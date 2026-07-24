using Asp.Versioning;
using ErMenu.Application.Features.landings.Queries.GetAppLanding;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ErMenu.Api.Controllers.V1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class LandingController(ISender sender) : ControllerBase
{
    [HttpGet("app")]
    public async Task<IActionResult> GetAppLanding()
        => Ok(await sender.Send(new GetAppLandingQuery()));
     
}
