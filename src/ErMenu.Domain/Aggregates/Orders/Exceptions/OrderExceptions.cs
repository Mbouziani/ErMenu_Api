using ErMenu.Domain.Common.Exceptions.Base;

namespace ErMenu.Domain.Aggregates.Orders.Exceptions;

public class OrderExceptions
{
    public static NotFoundException OrderNotFound()
        => new(OrderErrorCodes.OrderNotFound, "Order not found");
}
