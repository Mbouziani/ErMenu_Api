using ErMenu.Domain.Aggregates.Products.Entities;

namespace ErMenu.Domain.Aggregates.Orders.Entities;

public class OrderLine
{
    private OrderLine() { }

    public int OrderId { get; private set; }
    public Order Order { get; } = null!;

    public int ProductId { get; private set; }
    public Product Product { get; } = null!;

    public decimal Quantity { get; private set; }

    public decimal UnitPrice { get; private set; } 

    public decimal TotalAmount { get; private set; } 
  

    public static OrderLine Create(int productId, decimal quantity, decimal unitPrice)
    {
        return new OrderLine
        {
            ProductId = productId,
            Quantity = quantity,
            UnitPrice = unitPrice,
            TotalAmount = quantity * unitPrice
        };
    }

    public void IncreaseQuantity(decimal quantity)
    {
        Quantity += quantity;
        Recalculate();
    }
     
    private void Recalculate()
    {
        TotalAmount = Quantity * UnitPrice;
    }
}