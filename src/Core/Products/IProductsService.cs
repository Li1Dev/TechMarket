namespace TechMarket.Core.Products;

public interface IProductsService
{
    Task<Product> GetProductByIdAsync(int id, CancellationToken ct = default);

    Task<IReadOnlyList<Product>> GetListProductsAsync(
        string? search,
        int? companyId,
        int? categoryId,
        CancellationToken ct = default);
}