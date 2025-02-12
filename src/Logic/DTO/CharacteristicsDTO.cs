using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMarket.DAL.Entities;

namespace TechMarket.BLL.DTO
{
     public class CharacteristicsDTO
    {
        public int Id { get; set; }

        public CategoryDTO Category { get; set; } = null!;

        public string Name { get; set; } = null!;

        public List<CharacteristicProductDTO> characteristicsProducts { get; set; } = new();
    }
}
