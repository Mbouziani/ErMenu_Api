using ErMenu.Application.Common.Models.BaseResult;
using MediatR;

namespace ErMenu.Application.Features.Orders.Queries.GetOrderById;

public record GetOrderByIdQuery(int OrderId) : IRequest<Result<OrderDetailsDto>>;
