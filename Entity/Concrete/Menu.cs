using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Menu : BaseEntity
    {       
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Menu()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

    }
}
