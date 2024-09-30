using Infrustracture.Models;

namespace Infrustracture.Services.Interface;

public interface ICustomerService
{
    Task<bool> CreateCustomerAsync(Customers customer);
    Task<bool> UpdateCustomerAsync(Customers customer);
    Task<bool> DeleteCustomerAsync(Guid id);
    Task<Customers> GetCustomerByIdAsync(Guid id);
    Task<IEnumerable<Customers>> GetAllCustomersAsync();
    Task<IEnumerable<CustomersOrdersByCreatedAt>> GetCustomersOrdersAndByCreatedAtAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<CustomerStatistics>> GetCustomerStatisticsAsync();
    Task<IEnumerable<Customers>> GetCustomersOrdersInLastYearAsync();
}