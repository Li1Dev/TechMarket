using Microsoft.EntityFrameworkCore;
using TechMarket.Core.Orders;
using TechMarket.Data.Db.Entities;

namespace TechMarket.Data.Orders;

public class OrdersRepository : IOrdersRepository
{
    private readonly MarketContext _marketContext;

    public OrdersRepository(MarketContext marketContext)
    {
        _marketContext = marketContext ?? throw new ArgumentNullException(nameof(marketContext));
    }

    public async Task<Order> GetOrderByIdAsync(int id, CancellationToken ct = default)
    {
        var order = await _marketContext.Orders.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new Exception($"Order with id = {id} not found");

        return MapToOrder(order);
    }

    public async Task<IReadOnlyList<Order>> GetListOrderByUserIdAsync(int userId, CancellationToken ct = default)
    {
        var orders = await _marketContext.Orders
            .Where(x => x.CustomerId == userId)
            .Select(x => MapToOrder(x))
            .ToListAsync(ct);

        return orders;
    }

    private Order MapToOrder(OrderEntity order)
    {
        var res = new Order
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            Status = order.Status,
            DateTimeCreated = order.DateTimeCreated,
            DateTimeClose = order.DateTimeClose
        };

        return res;
    }
}