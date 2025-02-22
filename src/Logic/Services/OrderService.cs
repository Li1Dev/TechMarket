using AutoMapper;
using TechMarket.BLL.DTO;
using TechMarket.BLL.Infrastructure;
using TechMarket.BLL.Interfaces;
using TechMarket.DAL.Interfaces;
using TechMarket.Data.Db.Entities;

namespace TechMarket.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _database = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateOrder(OrderDTO orderDTO)
        {
            if (orderDTO == null)
            {
                throw new ValidationException("Заказ равен null", "");
            }

            for (int i = 0; i < orderDTO.Products.Count; i++)
            {
                Product? product = await _database.Products.GetByIdAsync(orderDTO.Products[i].Id);
                if (product == null)
                {
                    throw new ValidationException($"Товар: \"{orderDTO.Products[i].Name}\" не найден", ""); ;
                }
            }

            Order order = _mapper.Map<Order>(orderDTO);
            await _database.Orders.CreateAsync(order);
            _database.Save();
        }

        public async Task DeleteOrder(OrderDTO orderDTO)
        {
            if (orderDTO == null)
            {
                throw new ValidationException("Заказ равен null", "");
            }
            await _database.Orders.DeleteAsync(orderDTO.Id);
            _database.Save();
        }
    }
}
