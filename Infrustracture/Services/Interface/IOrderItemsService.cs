using Infrustracture.Models;

namespace Infrustracture.Services.Interface;

public interface IOrderItemsService
{
    Task<bool> CreateOrderItemsAsync(OrderItems orderItems);
    Task<bool> UpdateOrderItemsAsync(OrderItems orderItems);
    Task<bool> DeleteOrderItemsAsync(Guid id);
    Task<OrderItems> GetOrderItemsByIdAsync(Guid id);
    Task<IEnumerable<OrderItems>> GetAllOrderItemsAsync();
}