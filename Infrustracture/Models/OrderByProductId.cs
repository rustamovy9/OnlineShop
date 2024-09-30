namespace Infrustracture.Models;

public class OrderByProductId
{
    public Guid OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = null!;
    public string FullName { get; set; } = null!;
}