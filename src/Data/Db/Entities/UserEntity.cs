using Microsoft.AspNetCore.Identity;

namespace TechMarket.Data.Db.Entities;

public class UserEntity : IdentityUser
{
    public required string FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public DateOnly? BirthDate { get; set; }

    public List<OrderEntity>? Orders { get; set; }
}
