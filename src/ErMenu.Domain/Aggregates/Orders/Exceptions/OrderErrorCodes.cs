namespace ErMenu.Domain.Aggregates.Orders.Exceptions;

public class OrderErrorCodes
{
    public const string OrderIdRequired = "OrderIdRequired";
    public const string OrderNotFound = "OrderNotFound";
    public const string FailedToCreateOrder = "FailedToCreateOrder";
}
