namespace TechMarket.DAL.Entities;

public class Company
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public List<Product>? Products { get; set; }
}
