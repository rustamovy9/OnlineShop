namespace Infrustracture.SqlCommand;

public class SQLCommand
{
    public const string connectionString = "Server=localhost;Port=5432;Database=online_shop;User Id=postgres;Password=123456";

    #region Customers
    public const string createCustomer = "INSERT INTO Customers (FullName, Email, Phone, CreatedAt) VALUES (@FullName, @Email, @Phone, @CreatedAt)";
    public const string updateCustomer = "UPDATE Customers SET FullName=@FullName, Email=@Email, Phone=@Phone WHERE Id=@Id";
    public const string deleteCustomer = "DELETE FROM Customers WHERE Id=@Id";
    public const string getCustomerById = "SELECT * FROM Customers WHERE Id=@Id";
    public const string getAllCustomers = "SELECT * FROM Customers";
    #endregion
    
    #region Products
    public const string createProduct = "INSERT INTO Products (Name, Price, StockQuantity, CreatedAt) VALUES (@Name, @Price, @StockQuantity, @CreatedAt)";
    public const string updateProduct = "UPDATE Products SET Name=@Name, Price=@Price, StockQuantity=@StockQuantity WHERE Id=@Id";
    public const string deleteProduct = "DELETE FROM Products WHERE Id=@Id";
    public const string getProductById = "SELECT * FROM Products WHERE Id=@Id";
    public const string getAllProducts = "SELECT * FROM Products";
    #endregion
    
    #region Orders
    public const string createOrder = "INSERT INTO Orders (CustomerId, TotalAmount, OrderDate, Status, CreatedAt) VALUES (@CustomerId, @TotalAmount, @OrderDate, @Status, @CreatedAt)";
    public const string updateOrder = "UPDATE Orders SET TotalAmount=@TotalAmount, Status=@Status WHERE Id=@Id";
    public const string deleteOrder = "DELETE FROM Orders WHERE Id=@Id";
    public const string getOrderById = "SELECT * FROM Orders WHERE Id=@Id";
    public const string getAllOrders = "SELECT * FROM Orders";
    #endregion
    
    #region OrderItems
    public const string createOrderItem = "INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price, Created) VALUES (@OrderId, @ProductId, @Quantity, @Price, @CreatedAt)";
    public const string updateOrderItem = "UPDATE OrderItems SET OrderId=@OrderId,ProductId=@ProductId,Quantity=@Quantity, Price=@Price WHERE Id=@Id";
    public const string deleteOrderItem = "DELETE FROM OrderItems WHERE Id=@Id";
    public const string getOrderItemById = "SELECT * FROM OrderItems WHERE Id=@Id";
    public const string getAllOrderItems = "SELECT * FROM OrderItems";
    #endregion

    #region Queries
    public const string getAllCustomersOrderByCreatedAt = "SELECT c.FullName, c.Email,c.Phone, " +
                                                          "o.Id, o.Status, o.CreatedAt " +
                                                          "FROM Customers c " +
                                                          "JOIN Orders o ON o.CustomerId = c.Id " +
                                                          "WHERE o.CreatedAt BETWEEN @StartDate AND @EndDate";
    
    public const string getProductsTotalAmountIsNull = 
        "SELECT p.Name, p.Price, p.StockQuantity " +
        "FROM Products p " +
        "WHERE p.StockQuantity = 0";
    
        public const string getCustomerStatistic = "SELECT c.FullName, COUNT(o.Id) AS TotalOrders, SUM(o.TotalAmount) AS TotalSumAmount " +
                                                   "FROM Customers c " +
                                                   "JOIN Orders o ON c.Id = o.CustomerId " +
                                                   "GROUP BY c.FullName";
        
        public const string getOrdersCustomersAndProduct = "SELECT o.Id,c.Id as CustomerId,o.TotalAmount, o.OrderDate, o.Status,c.FullName, p.Name, oi.Quantity, oi.Price " +
                                                            "FROM Orders o " +
                                                            "JOIN Customers c ON o.CustomerId = c.Id " +
                                                            "JOIN OrderItems oi ON o.Id = oi.OrderId " +
                                                            "JOIN Products p ON oi.ProductId = p.Id;";
        
        public const string getOrdersByStatusAndDate = "SELECT o.Id, o.OrderDate, o.Status, c.FullName " +
                                                        "FROM Customers c JOIN Orders o ON c.Id = o.CustomerId " +
                                                        "WHERE o.Status = @Status and o.OrderDate between @StartDate AND @EndDate ";
        
        public const string getProductsPopular = "SELECT p.Name, SUM(oi.Quantity) as TotalSumQuantity " +
                                                  "FROM Products p JOIN OrderItems oi ON p.Id = oi.ProductId " +
                                                  "GROUP BY p.Name " +
                                                  "ORDER BY TotalSumQuantity DESC " +
                                                  "Limit 1";
        
        
    public const string getOrdersSalesStatistics = "SELECT SUM(o.TotalAmount) AS TotalSales, COUNT(o.Id) AS TotalCountOrders " +
                                                   "FROM Orders o " +
                                                   "WHERE EXTRACT(MONTH FROM o.OrderDate) = @month " +
                                                   "AND EXTRACT(YEAR FROM o.OrderDate) = @year;";
    
    public const string getCustomersOrdersInLastYear = "SELECT * " +
                                                       "FROM Customers c " +
                                                       "LEFT JOIN Orders o ON c.Id = o.CustomerId " +
                                                       "WHERE o.Id IS NULL AND o.CreatedAt < NOW() - INTERVAL '1 YEAR';";
    
    public const string getOrdersByProductId = "SELECT o.Id AS OrderId, o.OrderDate, o.Status, c.FullName " +
                                               "FROM Orders o " +
                                               "JOIN OrderItems oi ON o.Id = oi.OrderId " +
                                               "JOIN Customers c ON o.CustomerId = c.Id " +
                                               "WHERE oi.ProductId = @productId;";
    
    public const string getProductsTotalAmount = "SELECT p.Name, SUM(oi.Price * oi.Quantity) AS TotalAmount " +
                                                 "FROM Products p " +
                                                 "JOIN OrderItems oi ON p.Id = oi.ProductId " +
                                                 "GROUP BY p.Name;";

    #endregion
}
