using Asp.Versioning;
using ErMenu.Application.Features.Orders.Commands.CreateOrder;
using ErMenu.Application.Features.Orders.Queries.GetOrderById;
using ErMenu.Application.Features.Orders.Queries.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc; 

namespace ErMenu.Api.Controllers.V1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]

public class OrderController(ISender sender) : ControllerBase
{ 

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetOrdersQuery request)
        => Ok(await sender.Send(request));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await sender.Send(new GetOrderByIdQuery(id))); 

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand request)
        => Ok(await sender.Send(request));  
}
