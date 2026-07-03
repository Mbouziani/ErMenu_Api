using FluentValidation;

namespace ErMenu.Application.Features.Orders.Commands.CreateOrder;

internal class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {


        //RuleFor(x => x.OpenDescription)
        //   .NotEmpty()
        //   .WithMessage("Open description is required")
        //   .WithErrorCode(WorkOrderErrorCodes.OpenDescriptionRequired);

    }
}