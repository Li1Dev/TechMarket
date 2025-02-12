using TechMarket.BLL.DTO;

namespace TechMarket.BLL.Interfaces
{
    public interface IProductService
    {
        Task CreateProduct(ProductDTO product);

        Task<IEnumerable<ProductDTO>?> GetProducts();

        Task<ProductDTO?> GetProduct(int? id);

        void Dispose();
    }
}
