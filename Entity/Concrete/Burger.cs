using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Burger : BaseEntity
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Menu Menu { get; set; }
        public Burger()
        {
            Orders = new HashSet<Order>();
            Ingredients = new HashSet<Ingredient>();
        }

    }
}
