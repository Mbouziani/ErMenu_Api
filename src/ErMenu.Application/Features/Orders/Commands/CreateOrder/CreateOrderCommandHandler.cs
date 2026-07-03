using ErMenu.Application.Common.Interfaces;
using ErMenu.Application.Common.Interfaces.Security;
using ErMenu.Application.Common.Models.BaseResult;
using ErMenu.Domain.Aggregates.Orders.Entities;
using ErMenu.Domain.Aggregates.Orders.Repositories;
using MediatR;

namespace ErMenu.Application.Features.Orders.Commands.CreateOrder;

internal class CreateOrderCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentActor currentActor,
    IOrderRepository orderRepository)
    : IRequestHandler<CreateOrderCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var lastOrderNumber = await orderRepository.GetLastOrderNumberAsync(cancellationToken);

        var newOrderNumber = lastOrderNumber + 1;

        var order = Order.Create(newOrderNumber, currentActor.UserId);

        foreach (var line in request.Lines)
        {
            order.AddLine(line.ProductId, line.Quantity, line.UnitPrice);
        }

        await orderRepository.AddAsync(order, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(order.Id);
    }
}