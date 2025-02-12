
using TechMarket.DAL.Entities;

namespace TechMarket.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        Task CreateAsync(CustomerProfile customer);
    }
}
