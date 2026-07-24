using ErMenu.Application.Common.Models.BaseResult;
using MediatR;

namespace ErMenu.Application.Features.Orders.Commands.CreateOrder;



public sealed record class CreateOrderCommand(OrderDto Order) 
    : IRequest<Result<string>>;
