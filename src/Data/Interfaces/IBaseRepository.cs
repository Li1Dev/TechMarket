using System.Linq.Expressions;


namespace TechMarket.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        IQueryable<T>? FindAsync(Expression<Func<T, bool>> predecate);
    }
}
