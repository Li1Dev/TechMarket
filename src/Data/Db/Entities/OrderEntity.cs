namespace TechMarket.Data.Db.Entities;

public class OrderEntity
{
    public required int Id { get; set; }

    public required int CustomerId { get; set; }

    public required OrderStatusEnum Status { get; set; }

    public required DateTimeOffset DateTimeCreated { get; set; }

    public DateTimeOffset? DateTimeClose { get; set; }

    public required UserEntity Customer { get; set; }

    public List<ProductEntity>? Products { get; set; }
}
