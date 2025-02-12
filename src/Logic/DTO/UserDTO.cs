using TechMarket.DAL.Entities;

namespace TechMarket.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Address { get; set; }

        public string Role { get; set; } = null!;

        public List<Order> OrdersDTO { get; set; } = new();

    }
}
