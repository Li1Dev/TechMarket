namespace TechMarket.Data.Db.Entities;

public class CategoryEntity
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public List<ProductEntity>? Products { get; set; }
}
