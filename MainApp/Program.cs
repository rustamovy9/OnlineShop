using Infrustracture.Extansion;
using Infrustracture.Models;
using Infrustracture.Services;
using Infrustracture.Services.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRegisterService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


#region Customers
app.MapPost("/api/addcustomers", async ( Customers customers,ICustomerService customerService)=>
{
    return await customerService.CreateCustomerAsync(customers);
});

app.MapPut("/api/updatecustomer", async ( Customers customers,ICustomerService customerService)=>
{
    return await customerService.UpdateCustomerAsync(customers);
});

app.MapDelete("/api/deletecustomers/{id}", async ( Guid id,ICustomerService customerService)=>
{
    return await customerService.DeleteCustomerAsync(id);
});

app.MapGet("/api/getcustomer/{id}", async ( Guid id,ICustomerService customerService)=>
{
    return await customerService.GetCustomerByIdAsync(id);
});

app.MapGet("/api/getallcustomers", async (ICustomerService customerService)=>
{
    return await customerService.GetAllCustomersAsync();
});
#endregion

#region Products
app.MapPost("/api/addproducts", async (Products products, IProductService productService) =>
{
    return await productService.CreateProductAsync(products);
});

app.MapPut("/api/updateproducts", async (Products products, IProductService productService) =>
{
    return await productService.UpdateProductAsync(products);
});

app.MapDelete("/api/deleteproducts/{id}", async (Guid id, IProductService productService) =>
{
    return await productService.DeleteProductAsync(id);
});

app.MapGet("/api/getproduct/{id}", async (Guid id, IProductService productService) =>
{
    return await productService.GetProductByIdAsync(id);
});

app.MapGet("/api/getallproducts", async (IProductService productService) =>
{
    return await productService.GetAllProductsAsync();
});
#endregion

#region Orders
app.MapPost("/api/addorders", async (Orders orders, IOrderService orderService) =>
{
    return await orderService.CreateOrderAsync(orders);
});

app.MapPut("/api/updateorders", async (Orders orders, IOrderService orderService) =>
{
    return await orderService.UpdateOrderAsync(orders);
});

app.MapDelete("/api/deleteorders/{id}", async (Guid id, IOrderService orderService) =>
{
    return await orderService.DeleteOrderAsync(id);
});

app.MapGet("/api/getorder/{id}", async (Guid id, IOrderService orderService) =>
{
    return await orderService.GetOrderByIdAsync(id);
});

app.MapGet("/api/getallorders", async (IOrderService orderService) =>
{
    return await orderService.GetAllOrdersAsync();
});
#endregion

#region OrderItems
app.MapPost("api/addorderItems",async (IOrderItemsService orderItemsService,OrderItems orderItems)=>
{
    return await orderItemsService.CreateOrderItemsAsync(orderItems);
});
app.MapPut("api/updateorderItems", async (IOrderItemsService orderItemsService, OrderItems orderItems) =>
{
    return await orderItemsService.UpdateOrderItemsAsync(orderItems);
});
app.MapDelete("api/deleteorderItems/{id}", async (Guid id, IOrderItemsService orderItemsService) =>
{
    return await orderItemsService.DeleteOrderItemsAsync(id);
});
app.MapGet("api/getorderItems/{id}", async (Guid id, IOrderItemsService orderItemsService) =>
{
    return await orderItemsService.GetOrderItemsByIdAsync(id);
});
app.MapGet("api/getallorderItems", async (IOrderItemsService orderItemsService) =>
{
    return await orderItemsService.GetAllOrderItemsAsync();
});
#endregion

#region Queries
app.MapGet("/api/customers/orders", async (DateTime startDate,DateTime endDate,ICustomerService customerService) =>
{
    return await customerService.GetCustomersOrdersAndByCreatedAtAsync(startDate, endDate);
});
app.MapGet("api/products/out-of-stock",async (IProductService productService)=>
{
    return await productService.GetProductsTotalAmountIsNullAsync();
});
app.MapGet("api/customers/statistics",async (ICustomerService customerService)=>
{
    return await customerService.GetCustomerStatisticsAsync();
});
app.MapGet("api/orders/details",async (IOrderService orderService)=>
{
    return await orderService.GetOrdersCustomersAndProductAsync();
});
app.MapGet("api/orders/status={status}&startDate={startDate}&endDate={endDate}", async (string status,DateTime startDate,DateTime endDate,IOrderService orderService) =>
{
    return await orderService.GetOrdersByStatusAndDateAsync(status,startDate,endDate); 
});
app.MapGet("api/products/popular",async (IProductService productService)=>
{
    return await productService.GetPopularProsuctsAsync();
});
app.MapGet("api/orders/sales-statistics/month={month}&year={year}", async (IOrderService orderService, int month, int year) =>
{
    return await orderService.GetOrdersSalesStatisticsAsync(month, year);
});
app.MapGet("api/customers/inactive", (ICustomerService customerService) =>
{
    return customerService.GetCustomersOrdersInLastYearAsync();
});
app.MapGet("api/products/{productId}/orders", (IOrderService orderService, Guid productId) =>
{
    return orderService.GetOrdersByProductIdAsync(productId);
});
app.MapGet("api/orders/products-summary", async (IProductService productService) =>
{
    return await productService.GetProductsTotalAmountAsync();
});
#endregion

app.Run();
