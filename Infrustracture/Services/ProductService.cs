using Dapper;
using Infrustracture.Models;
using Infrustracture.Services.Interface;
using Infrustracture.SqlCommand;
using Npgsql;

namespace Infrustracture.Services;

public class ProductService:IProductService
{
    public async Task<bool> CreateProductAsync(Products products)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.createProduct,products) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
            
        }
    }

    public async Task<bool> UpdateProductAsync(Products products)
    {
        try
        {
            using (NpgsqlConnection conn = new (SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.updateProduct, products) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteProductAsync(Guid productId)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.deleteProduct, new {Id=productId}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Products> GetProductByIdAsync(Guid productId)
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Products>(SQLCommand.getProductById, new {Id=productId});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Products>> GetAllProductsAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Products>(SQLCommand.getAllProducts);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<ProductTotalAmountIsNull>> GetProductsTotalAmountIsNullAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new (SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<ProductTotalAmountIsNull>(SQLCommand.getProductsTotalAmountIsNull);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<PopularProducts>> GetPopularProsuctsAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<PopularProducts>(SQLCommand.getProductsPopular);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<ProductToTalAmount>> GetProductsTotalAmountAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new(SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<ProductToTalAmount>(SQLCommand.getProductsTotalAmount);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}