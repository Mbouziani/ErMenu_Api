namespace ErMenu.Application.Features.Orders.Commands.CreateOrder;

public class OrderLineDto
{
    public int ProductId { get; set; } 
    public int SizeId { get;  set; } 
    public string Barecode { get; set; } = string.Empty;
     
    public int Quantity { get;  set; }

    public decimal NetUnitPrice { get; set; } 

    public decimal NetAmount { get; set; } 

    public decimal TaxAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal DiscountAmount { get; set; }


    public string AdditionalInfo { get; set; } = string.Empty;

}
