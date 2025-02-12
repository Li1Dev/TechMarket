using Microsoft.AspNetCore.Identity;
using TechMarket.DAL.EF;
using TechMarket.DAL.Entities;
using TechMarket.DAL.Interfaces;

namespace TechMarket.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext? db;

        private ProductRepository? productRepository;
        private OrderRepository? orderRepository;

        private IClientManager? clientManager;

        public UserManager<ApplicationUser> UserManager { get; set; }
        public RoleManager<ApplicationRole> RoleManager { get; set; }

        public EFUnitOfWork(ApplicationContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this.db = db;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public IRepository<Product> Products
        {
            get
            {
                productRepository ??= new ProductRepository(db!);
                return productRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                orderRepository ??= new OrderRepository(db!);
                return orderRepository;
            }
        }

        public IClientManager ClientManager
        {
            get
            {
                clientManager ??= new ClientManager(db!);
                return clientManager;
            }
        }

        public async Task SaveAsync()
        {
            await db!.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db!.Dispose();
                    RoleManager.Dispose();
                    UserManager.Dispose();
                    ClientManager.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
    }
}
