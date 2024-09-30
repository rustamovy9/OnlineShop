namespace Infrustracture.Models;

public class CustomerStatistics
{
    public string FullName { get; set; } = null!;
    public int TotalOrders { get; set; }
    public int TotalSumAmount { get; set; }
}