using ErMenu.Application.Common.Interfaces.Security;
using ErMenu.Application.Common.Models.BaseResult;
using ErMenu.Application.Common.Models.Pagination;
using ErMenu.Domain.Aggregates.Orders.Repositories;
using MediatR;

namespace ErMenu.Application.Features.Orders.Queries.GetOrders;

internal class GetOrdersQueryHandler(
    IOrderRepository orderRepository,
    ICurrentActor currentActor)
    : IRequestHandler<GetOrdersQuery, Result<PaginatedResult<OrderDto>>>
{
    public async Task<Result<PaginatedResult<OrderDto>>> Handle(
        GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var queryable = orderRepository.QueryNoTracking();

        queryable = queryable.Where(u => u.CreatorId == currentActor.UserId);

        var response = await queryable
            .Select(workOrder => new OrderDto
            {
                Id = workOrder.Id,
                CreatedAt = workOrder.CreatedAt,
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PaginatedResult<OrderDto>>.Success(response);
    }
}