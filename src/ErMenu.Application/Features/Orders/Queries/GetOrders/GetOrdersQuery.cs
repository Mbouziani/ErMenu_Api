using ErMenu.Application.Common.Models.BaseResult;
using ErMenu.Application.Common.Models.Pagination;
using MediatR;

namespace ErMenu.Application.Features.Orders.Queries.GetOrders;

public class GetOrdersQuery : PaginationQuery, IRequest<Result<PaginatedResult<OrderDto>>>
{
}