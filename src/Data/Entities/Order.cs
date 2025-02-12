namespace TechMarket.DAL.Entities;

public class Order
{
    public required int Id { get; set; }

    public required ApplicationUser Customer { get; set; }

    public required OrderStatus Status { get; set; }

    public required DateTimeOffset DateTimeCreated { get; set; }

    public List<Product>? Products { get; set; }
}
