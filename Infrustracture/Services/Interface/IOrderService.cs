using Infrustracture.Models;

namespace Infrustracture.Services.Interface;

public interface IOrderService
{
    Task<bool> CreateOrderAsync(Orders orders);
    Task<bool> UpdateOrderAsync(Orders orders);
    Task<bool> DeleteOrderAsync(Guid orderId);
    Task<Orders> GetOrderByIdAsync(Guid orderId);
    Task<IEnumerable<Orders>> GetAllOrdersAsync();
    Task<IEnumerable<OrderCustomerAndProduct>> GetOrdersCustomersAndProductAsync();
    Task<IEnumerable<OrdersByStatusAndDate>> GetOrdersByStatusAndDateAsync(string status, DateTime startDate, DateTime endDate);
    Task<OrderSalesStatics> GetOrdersSalesStatisticsAsync(int month, int year);
    Task<IEnumerable<OrderByProductId>> GetOrdersByProductIdAsync(Guid productId);
}