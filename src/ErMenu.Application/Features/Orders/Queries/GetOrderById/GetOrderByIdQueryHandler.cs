using ErMenu.Application.Common.Mappers;
using ErMenu.Application.Common.Models.BaseResult;
using ErMenu.Domain.Aggregates.Orders.Exceptions;
using ErMenu.Domain.Aggregates.Orders.Repositories;
using MediatR;

namespace ErMenu.Application.Features.Orders.Queries.GetOrderById;

internal class GetOrderByIdQueryHandler(
    IOrderRepository orderRepository)
    : IRequestHandler<GetOrderByIdQuery, Result<OrderDetailsDto>>
{
    public async Task<Result<OrderDetailsDto>> Handle(
        GetOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetOrderIncludeLinesByIdAsync(
            request.OrderId, cancellationToken)
            ?? throw OrderExceptions.OrderNotFound();


        var response = new OrderDetailsDto()
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            Creator = UserMapper.ToActorDto(order.Creator),
            Lines = [.. order.Lines.Select(line => new OrderLineDto()
            {
                //Id = line.Id,
                //ProductId = line.ProductId,
                //ProductName = line.ProductName,
                //Quantity = line.Quantity,
                //Price = line.Price
            })]
        };

        return Result<OrderDetailsDto>.Success(response);
    }
}