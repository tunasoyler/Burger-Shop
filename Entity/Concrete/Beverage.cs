using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Beverage :BaseEntity
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public Beverage()
        {
            Menus = new HashSet<Menu>();
        }

    }
}
