namespace TechMarket.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public CustomerProfileDTO? Customer { get; set; }

        public DateTime DateTime { get; set; }

        public List<ProductDTO> Products { get; set; } = new();
    }
}
