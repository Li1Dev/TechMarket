namespace TechMarket.Core.Products;

public interface IProductsRepository
{
    Task<Product> GetProductByIdAsync(int id, CancellationToken ct = default);

    Task<IReadOnlyList<Product>> GetListProductsAsync(
        string? search,
        int? companyId,
        int? categoryId,
        CancellationToken ct = default);
}