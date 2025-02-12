namespace TechMarket.DAL.Entities;

public class Category
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public List<Product>? Products { get; set; }

    public List<Characteristic>? Characteristics { get; set; }
}
