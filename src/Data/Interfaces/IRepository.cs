using System.Linq.Expressions;

namespace TechMarket.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);

        void Update(T entity);

        Task DeleteAsync(int id);

        Task<IEnumerable<T>?> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task<IEnumerable<T>?> FindAsync(Expression<Func<T, bool>> predecate);
    }
}
