namespace TechMarket.Core.Products;

public record Product
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public required int CompanyId { get; init; }

    public required int CategoryId { get; init; }

    public required decimal Price { get; init; }

    public string? Discription { get; init; }
}
