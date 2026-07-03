using ErMenu.Domain.Aggregates.Orders.Exceptions;
using FluentValidation;

namespace ErMenu.Application.Features.Orders.Queries.GetOrderById;

internal class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdQueryValidator()
    {
        RuleFor(x => x.OrderId)
           .NotEmpty()
           .WithMessage("Order ID is required")
           .WithErrorCode(OrderErrorCodes.OrderIdRequired);

    }
}