namespace TechMarket.DAL.Entities;

public class Characteristic
{
    public required int Id { get; set; }

    public required Category Category { get; set; }

    public required string Name { get; set; }

    public required List<CharacteristicProduct>? CharacteristicsProducts { get; set; }
}
