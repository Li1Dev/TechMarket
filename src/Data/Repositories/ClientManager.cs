using TechMarket.DAL.EF;
using TechMarket.DAL.Entities;
using TechMarket.DAL.Interfaces;

namespace TechMarket.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public readonly ApplicationContext db;

        public ClientManager(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(CustomerProfile customer)
        {
            await db.CustomerProfiles.AddAsync(customer);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
