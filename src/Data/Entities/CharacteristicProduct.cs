namespace TechMarket.DAL.Entities;

public class CharacteristicProduct
{
    public required int Id { get; set; }

    public required Product Product { get; set; }

    public required Characteristic Characteristic { get; set; }

    public required string Value { get; set; }
}
