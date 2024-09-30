using Infrustracture.Models;

namespace Infrustracture.Services.Interface;

public interface IProductService
{
    Task<bool> CreateProductAsync(Products products);
    Task<bool> UpdateProductAsync(Products products);
    Task<bool> DeleteProductAsync(Guid productId);
    Task<Products> GetProductByIdAsync(Guid productId);
    Task<IEnumerable<Products>> GetAllProductsAsync();
    Task<IEnumerable<ProductTotalAmountIsNull>> GetProductsTotalAmountIsNullAsync();
    Task<IEnumerable<PopularProducts>> GetPopularProsuctsAsync();
    Task<IEnumerable<ProductToTalAmount>> GetProductsTotalAmountAsync();
}