using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Burger : BaseEntity
    {
        public ICollection<Ingredient> Ingredients { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
