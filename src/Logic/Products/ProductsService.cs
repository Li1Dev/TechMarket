using TechMarket.Core.Products;

namespace TechMarket.Logic.Products;

public class ProductsService : IProductsService
{
    private readonly IProductsRepository _productsRepository;

    public ProductsService(IProductsRepository productsRepository)
    {
        _productsRepository = _productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
    }

    public async Task<Product> GetProductByIdAsync(int id, CancellationToken ct = default)
    {
        var res = await _productsRepository.GetProductByIdAsync(id, ct);

        return res;
    }

    public async Task<IReadOnlyList<Product>> GetListProductsAsync(string? search, int? companyId, int? categoryId, CancellationToken ct = default)
    {
        var res = await _productsRepository.GetListProductsAsync(
            search,
            companyId,
            categoryId,
            ct);

        return res;
    }
}