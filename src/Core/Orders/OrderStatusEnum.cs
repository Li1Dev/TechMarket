namespace TechMarket.Core.Orders;

public enum OrderStatusEnum
{
    Accept,
    Processing,
    PaymentWait,
    Delivery,
    Completed,
    Cancelled
}