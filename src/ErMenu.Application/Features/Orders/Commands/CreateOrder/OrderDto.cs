namespace ErMenu.Application.Features.Orders.Commands.CreateOrder;

public class OrderDto
{
    public decimal NetAmount { get; set; } 

    public decimal TaxAmount { get; set; }

    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }


    public double CardPaymentAmount { get; set; } 

    public int? CustomerId { get; set; }
    public int MethodId { get; set; }


    public List<OrderLineDto> Lines { get; set; } = [];

}
