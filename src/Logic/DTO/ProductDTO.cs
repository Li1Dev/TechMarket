namespace TechMarket.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public CompanyDTO? Company { get; set; }

        public CategoryDTO? Category { get; set; }

        public decimal Price { get; set; }

        public string? Discription { get; set; }

        public List<CharacteristicProductDTO> CharacteristicsProduct { get; set; } = new();
    }
}
