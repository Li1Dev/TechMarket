namespace TechMarket.Core.Orders;

public interface IOrdersRepository
{
    Task<Order> GetOrderByIdAsync(int id, CancellationToken ct = default);

    Task<IReadOnlyList<Order>> GetListOrderByUserIdAsync(int userId, CancellationToken ct = default);
}