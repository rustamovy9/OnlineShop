using Dapper;
using Infrustracture.Models;
using Infrustracture.Services.Interface;
using Infrustracture.SqlCommand;
using Npgsql;

namespace Infrustracture.Services;

public class OrderItemService:IOrderItemsService
{
    public async Task<bool> CreateOrderItemsAsync(OrderItems orderItems)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.createOrderItem,orderItems)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateOrderItemsAsync(OrderItems orderItems)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.updateOrderItem, orderItems)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteOrderItemsAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection conn = new (SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.deleteOrderItem, new { Id = id })>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<OrderItems> GetOrderItemsByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QuerySingleAsync<OrderItems>(SQLCommand.getOrderItemById, new { Id = id });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }   
    }

    public async Task<IEnumerable<OrderItems>> GetAllOrderItemsAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<OrderItems>(SQLCommand.getAllOrderItems);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}