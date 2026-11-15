namespace ErMenu.Application.Features.Orders.Commands.CreateOrder;

public class OrderLineDto
{
    public int ProductId { get; set; } 
    public int SizeId { get;  set; } 
    public string Barecode { get; set; } = string.Empty;
     
    public int Quantity { get;  set; }

    public decimal OneUnitAmountBeforeVat { get; set; }

    public decimal TotalAmountBeforeVat { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal NetAmountAfterDiscount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal TotalAmount { get; set; }

     
    public string AdditionalInfo { get; set; } = string.Empty;



}
