using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Internal;
using TechMarket.Core.Orders;
using TechMarket.Data.Db.Entities;

namespace TechMarket.Data.Orders;

public class OrdersRepository : IOrdersRepository
{
    private readonly MarketContext _marketContext;
    private readonly ISystemClock _systemClock;

    public OrdersRepository(
        MarketContext marketContext,
        ISystemClock systemClock)
    {
        _marketContext = marketContext ?? throw new ArgumentNullException(nameof(marketContext));
        _systemClock = systemClock ?? throw new ArgumentNullException(nameof(systemClock));
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
            .ToListAsync(ct)
            ?? throw new Exception($"Order fot user = {userId} not found");


        return orders;
    }

    public async Task<Order> CreateOrderAsync(int userId, IReadOnlyList<int> productsIds, CancellationToken ct = default)
    {
        var order = new OrderEntity
        {
            Id = 0,
            CustomerId = userId,
            Status = OrderStatusEnum.Accept,
            DateTimeCreated = _systemClock.UtcNow
        };

        await _marketContext.Orders.AddAsync(order, ct);
        await _marketContext.SaveChangesAsync(ct);

        return MapToOrder(order);
    }


    private static Order MapToOrder(OrderEntity order)
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