namespace TechMarket.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public CompanyViewModel? Company { get; set; }

        public CategoryViewModel? Category { get; set; }

        public decimal Price { get; set; }

        public string? Discription { get; set; }
    }
}
