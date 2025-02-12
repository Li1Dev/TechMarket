namespace TechMarket.Models
{
    internal class OrderViewModel
    {
        public int Id { get; set; }

        public CustomerViewModel? Customer { get; set; }

        public DateTime DateTime { get; set; }

        public List<ProductViewModel> Products { get; set; } = new();
    }
}
