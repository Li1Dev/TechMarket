namespace TechMarket.DAL.Entities;

public class CustomerProfile
{
    public required int Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public string? Address { get; set; }

    public List<Order>? Orders { get; set; }

    public required ApplicationUser User { get; set; }
}
