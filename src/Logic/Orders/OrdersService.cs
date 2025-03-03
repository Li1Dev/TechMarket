using TechMarket.Core.Orders;

namespace TechMarket.Logic.Orders;

public class OrdersService : IOrdersService
{
    private readonly IOrdersRepository _ordersRepository;

    public OrdersService(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
    }

    public async Task<Order> GetOrderByIdAsync(int id, CancellationToken ct = default)
    {
        var res = await _ordersRepository.GetOrderByIdAsync(id, ct);

        return res;
    }

    public async Task<IReadOnlyList<Order>> GetListOrderByUserIdAsync(int userId, CancellationToken ct = default)
    {
        var res = await _ordersRepository.GetListOrderByUserIdAsync(userId, ct);

        return res;
    }

    public Task<Order> CreateOrderAsync(int userId, IReadOnlyList<int> productsIds, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}