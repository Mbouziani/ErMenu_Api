using ErMenu.Domain.Aggregates.Users.Entities;

namespace ErMenu.Domain.Aggregates.Orders.Entities;

public class Order
{
    private Order() { }
     
     
    public int Id { get; private set; }

    public int CreatorId { get; private set; }
    public User Creator { get; } = null!;

    public int LinesCount { get; private set; }

    public decimal TotalAmount { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;

    public ICollection<OrderLine> Lines { get; private set; } = [];

    public static Order Create(int orderId, int creatorId)
    {
        return new Order
        {
            Id = orderId,
            CreatorId = creatorId
        };
    }

    public void AddLine(int productId, decimal quantity, decimal unitPrice)
    {
        var existingLine = Lines.FirstOrDefault(x => x.ProductId == productId);

        if (existingLine is not null)
        {
            existingLine.IncreaseQuantity(quantity);
        }
        else
        {
            Lines.Add(OrderLine.Create(productId, quantity, unitPrice));
        }

        Recalculate();
    }

      

    private void Recalculate()
    {
        LinesCount = Lines.Count;
        TotalAmount = Lines.Sum(x => x.TotalAmount);
    }
}