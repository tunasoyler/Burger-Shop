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
        public Burger Burger { get; set; }
        public int BurgerId { get; set; }
        public Beverage Beverage { get; set; }
        public int BeverageId { get; set; }
        public ExtraSnack ExtraSnack { get; set; }
        public int ExtraSnackId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Menu()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

    }
}
