using Infrustracture.Services;
using Infrustracture.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Infrustracture.Extansion;

public static class Extansion
{
    public static void AddRegisterService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICustomerService, CustomerService>();
        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<IOrderService, OrderService>();
        serviceCollection.AddScoped<IOrderItemsService, OrderItemService>();
    }
}