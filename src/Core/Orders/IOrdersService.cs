namespace TechMarket.Core.Orders;

public interface IOrdersService
{
    Task<Order> GetOrderByIdAsync(int id, CancellationToken ct = default);

    Task<IReadOnlyList<Order>> GetListOrderByUserIdAsync(int userId, CancellationToken ct = default);

    Task<Order> CreateOrderAsync(int userId, IReadOnlyList<int> productsIds, CancellationToken ct = default);
}