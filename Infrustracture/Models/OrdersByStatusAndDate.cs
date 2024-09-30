namespace Infrustracture.Models;

public class OrdersByStatusAndDate
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = null!;
    public string FullName { get; set; } = null!;
}