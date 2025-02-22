namespace TechMarket.Data.Db.Entities;

public class ProductEntity
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required int CompanyId { get; set; }

    public required int CategoryId { get; set; }

    public required decimal Price { get; set; }

    public string? Discription { get; set; }

    public CompanyEntity? Company { get; set; }

    public CategoryEntity? Category { get; set; }

    public List<OrderEntity>? Orders { get; set; }
}

