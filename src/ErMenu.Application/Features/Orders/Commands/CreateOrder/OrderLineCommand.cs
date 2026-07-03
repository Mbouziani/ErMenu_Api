namespace ErMenu.Application.Features.Orders.Commands.CreateOrder;

public class OrderLineCommand
{
    public int ProductId { get; private set; }

    public decimal Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal TotalAmount { get; private set; }
}
