using Asp.Versioning;
using ErMenu.Application.Features.Orders.Commands.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ErMenu.Api.Controllers.V1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]

public class OrderController(ISender sender) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand request)
        => Ok(await sender.Send(request));
}
