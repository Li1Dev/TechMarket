using AutoMapper;
using TechMarket.BLL.DTO;
using TechMarket.BLL.Infrastructure;
using TechMarket.BLL.Interfaces;
using TechMarket.DAL.Entities;
using TechMarket.DAL.Interfaces;

namespace TechMarket.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _database = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateProduct(ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                throw new ValidationException("Продукт равен null", "");
            }
            IEnumerable<Product>? products = await _database.Products.FindAsync(p => p.Name == productDTO.Name && _mapper.Map<CategoryDTO>(p.Category) == productDTO.Category && _mapper.Map<CompanyDTO>(p.Company) == productDTO.Company);
            if ( products == null) {
                throw new ValidationException("Такой тавар уже существует", "");
            }
            Product product = _mapper.Map<Product>(productDTO);
            await _database.Products.CreateAsync(product);
            await _database.SaveAsync();
            
        }

        public async Task<IEnumerable<ProductDTO>?> GetProducts()
        {
            return _mapper.Map<IEnumerable<Product>?, IEnumerable<ProductDTO>?>(await _database.Products.GetAllAsync());
        }

        public async Task<ProductDTO?> GetProduct(int? id)
        {
            if(id == null)
            {
                throw new ValidationException("Не установлено ID продукта", "");
            }
            Product? product = await _database.Products.GetByIdAsync(id.Value);
            if(product == null)
            {
                throw new ValidationException("Продукт не найден","");
            }

            ProductDTO? productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }
  
        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
