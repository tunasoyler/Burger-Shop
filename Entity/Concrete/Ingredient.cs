using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Ingredient : BaseEntity
    {
        public ICollection<Burger> Burgers { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
