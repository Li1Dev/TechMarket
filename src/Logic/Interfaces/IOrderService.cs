using TechMarket.BLL.DTO;

namespace TechMarket.BLL.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(OrderDTO orderDTO);

        Task DeleteOrder(OrderDTO orderDTO);
    }
}
