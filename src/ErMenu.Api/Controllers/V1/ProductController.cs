using Asp.Versioning;
using ErMenu.Application.Features.Products.Queries.GetCategoriesIncludeProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ErMenu.Api.Controllers.V1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductController(ISender sender) : ControllerBase
{
    [HttpGet("in-categories")]
    public async Task<IActionResult> GetCategoriesIncludeProducts()
        => Ok(await sender.Send(new GetCategoriesIncludeProductsQuery()));
     
}
