using Dapper;
using Infrustracture.Models;
using Infrustracture.Services.Interface;
using Infrustracture.SqlCommand;
using Npgsql;

namespace Infrustracture.Services;

public class OrderService:IOrderService
{
    public async Task<bool> CreateOrderAsync(Orders orders)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.createOrder,orders)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateOrderAsync(Orders orders)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.updateOrder,orders)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteOrderAsync(Guid orderId)
    {
        try
        {
            using (NpgsqlConnection conn = new (SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.deleteOrder,new {Id=orderId })>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Orders> GetOrderByIdAsync(Guid orderId)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Orders>(SQLCommand.getOrderById, new {Id=orderId });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Orders>> GetAllOrdersAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Orders>(SQLCommand.getAllOrders);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<OrderCustomerAndProduct>> GetOrdersCustomersAndProductAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new (SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<OrderCustomerAndProduct>(SQLCommand.getOrdersCustomersAndProduct);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<OrdersByStatusAndDate>> GetOrdersByStatusAndDateAsync(string status, DateTime startDate, DateTime endDate)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<OrdersByStatusAndDate>(SQLCommand.getOrdersByStatusAndDate, new {Status=status, startDate, endDate });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<OrderSalesStatics> GetOrdersSalesStatisticsAsync(int month, int year)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<OrderSalesStatics>(SQLCommand.getOrdersSalesStatistics, new { month, year });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<OrderByProductId>> GetOrdersByProductIdAsync(Guid productId)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<OrderByProductId>(SQLCommand.getOrdersByProductId, new {productId });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}