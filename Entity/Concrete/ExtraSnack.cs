using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class ExtraSnack : BaseEntity
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
