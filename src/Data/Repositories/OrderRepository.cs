using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechMarket.DAL.EF;
using TechMarket.DAL.Entities;
using TechMarket.DAL.Interfaces;

namespace TechMarket.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ApplicationContext _db;

        public OrderRepository(ApplicationContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task CreateAsync(Order order)
        {
            await _db.Orders.AddAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            Order? order = await _db.Orders.FindAsync(id);
            if (order != null)
                _db.Orders.Remove(order);
        }  

        public async Task<IEnumerable<Order>?> GetAllAsync()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _db.Orders.FindAsync(id);
        }

        public void Update(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Order>?> FindAsync(Expression<Func<Order, bool>> predecate)
        {
            return await _db.Orders.Where(predecate).ToListAsync();
        }
    }
}
