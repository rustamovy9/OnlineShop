namespace Infrustracture.Models;

public class CustomersOrdersByCreatedAt
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public Guid Id { get; set; }
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}