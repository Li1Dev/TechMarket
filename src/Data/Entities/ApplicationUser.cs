using Microsoft.AspNetCore.Identity;

namespace TechMarket.DAL.Entities;

public class ApplicationUser : IdentityUser
{
    public required CustomerProfile Profile { get; set; }
}
