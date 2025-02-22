namespace TechMarket.Data.Db.Entities;

public class CompanyEntity
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public List<ProductEntity>? Products { get; set; }
}
