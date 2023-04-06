using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Extra : BaseEntity
    {
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ExtraCategory ExtraCategory { get; set; }
        public int ExtraCategoryId { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public Extra()
        {
            OrderDetails = new List<OrderDetails>();
        }
    }
}
