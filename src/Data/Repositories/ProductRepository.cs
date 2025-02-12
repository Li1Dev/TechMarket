using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechMarket.DAL.EF;
using TechMarket.DAL.Entities;
using TechMarket.DAL.Interfaces;

namespace TechMarket.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationContext db;

        public ProductRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(Product product)
        {
            await db.Products.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            Product? product = await db.Products.FindAsync(id);
            if (product != null)
                db.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            return await db.Products.Include(p => p.Company).Include(p => p.Category).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Product>?> FindAsync(Expression<Func<Product, bool>> predecate)
        {
            return await db.Products.Where(predecate).ToListAsync();
        }
    }
}
