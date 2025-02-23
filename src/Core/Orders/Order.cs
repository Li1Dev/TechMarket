namespace TechMarket.Core.Orders;

public class Order
{
    public required int Id { get; set; }

    public required int CustomerId { get; set; }

    public required OrderStatusEnum Status { get; set; }

    public required DateTimeOffset DateTimeCreated { get; set; }

    public DateTimeOffset? DateTimeClose { get; set; }
}
