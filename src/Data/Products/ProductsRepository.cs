#pragma warning disable CA1862 // Prefer the string comparison method overload of ...
using System.Data;
using Microsoft.EntityFrameworkCore;
using TechMarket.Core.Products;
using TechMarket.Data.Db.Entities;

namespace TechMarket.Data.Products;

public class ProductsRepository : IProductsRepository
{
    private readonly MarketContext _marketContext;

    public ProductsRepository(MarketContext marketContext)
    {
        _marketContext = marketContext ?? throw new ArgumentNullException(nameof(marketContext));
    }

    ///TODO: add custom exception
    public async Task<Product> GetProductByIdAsync(int id, CancellationToken ct = default)
    {
        var product = await _marketContext.Products.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new Exception($"Product with id = {id} not found");

        return MapToProduct(product);
    }

    public async Task<IReadOnlyList<Product>> GetListProductsAsync(
        string? search,
        int? companyId,
        int? categoryId,
        CancellationToken ct = default)
    {
        var query = _marketContext.Products.AsQueryable();

        if (search != null)
        {
            query = query.Where(x => x.Name.ToUpper().Contains(search.ToUpper()));
        }

        if (companyId == null)
        {
            query = query.Where(x => x.CompanyId == companyId);
        }

        if (categoryId != null)
        {
            query = query.Where(x => x.CategoryId == categoryId);
        }

        return await query.Select(x => MapToProduct(x)).ToListAsync(ct);
    }

    private static Product MapToProduct(ProductEntity product)
    {
        var res = new Product
        {
            Id = product.Id,
            Name = product.Name,
            CompanyId = product.CompanyId,
            CategoryId = product.CategoryId,
            Price = product.Price,
            Discription = product.Discription
        };

        return res;
    }
}