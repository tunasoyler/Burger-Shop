using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Desert : BaseEntity
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Desert()
        {
            OrderDetails = new List<OrderDetails>();
        }

    }
}
