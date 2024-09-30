using Dapper;
using Infrustracture.Models;
using Infrustracture.Services.Interface;
using Infrustracture.SqlCommand;
using Npgsql;

namespace Infrustracture.Services;

public class CustomerService:ICustomerService
{
    public async Task<bool> CreateCustomerAsync(Customers customer)
    {
        try
        {
            using (NpgsqlConnection conn = new (SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.createCustomer, customer) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateCustomerAsync(Customers customer)
    {
        try
        {
            using (NpgsqlConnection conn = new (SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.updateCustomer, customer) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteCustomerAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection conn = new (SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.deleteCustomer,new {Id=id}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Customers> GetCustomerByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection conn = new (SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Customers>(SQLCommand.getCustomerById,new {Id=id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Customers>> GetAllCustomersAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new (SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Customers>(SQLCommand.getAllCustomers);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<CustomersOrdersByCreatedAt>> GetCustomersOrdersAndByCreatedAtAsync(DateTime startDate, DateTime endDate)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
               await conn.OpenAsync();
               return await conn.QueryAsync<CustomersOrdersByCreatedAt>(SQLCommand.getAllCustomersOrderByCreatedAt, new {startDate, endDate });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<CustomerStatistics>> GetCustomerStatisticsAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<CustomerStatistics>(SQLCommand.getCustomerStatistic);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Customers>> GetCustomersOrdersInLastYearAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Customers>(SQLCommand.getCustomersOrdersInLastYear);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}