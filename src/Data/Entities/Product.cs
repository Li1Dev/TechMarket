namespace TechMarket.DAL.Entities;

public class Product
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required Company Company { get; set; }

    public Category? Category { get; set; }

    public decimal Price { get; set; }

    public required string Discription { get; set; }

    public List<Order>? Orders { get; set; } 

    public List<CharacteristicProduct>? CharacteristicsProduct { get; set; }
}

