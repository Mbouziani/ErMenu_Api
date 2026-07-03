using ErMenu.Application.Common.Models.BaseResult;
using MediatR;

namespace ErMenu.Application.Features.Orders.Commands.CreateOrder;



public sealed record class CreateOrderCommand(List<OrderLineCommand> Lines) 
    : IRequest<Result<int>>;
