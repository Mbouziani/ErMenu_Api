using ErMenu.Application.Common.DTOs.Users;

namespace ErMenu.Application.Features.Orders.Queries.GetOrderById;


public class OrderDetailsDto
{
    public int Id { get; init; }
    public DateTimeOffset CreatedAt { get; set; }


    public ActorDto Creator { get; init; } = null!;


    public List<OrderLineDto> Lines { get; set; } = [];

}
