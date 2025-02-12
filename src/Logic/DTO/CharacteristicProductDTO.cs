namespace TechMarket.BLL.DTO
{
    public class CharacteristicProductDTO
    {
        public int Id { get; set; }

        public ProductDTO Product { get; set; } = null!;

        public CharacteristicsDTO Characteristic { get; set; } = null!;

        public string Value { get; set; } = null!;
    }
}