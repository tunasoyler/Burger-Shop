using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class OrderDetails :BaseEntity
    {
        public int MenuId { get; set; }
        public int BeverageId { get; set; }
        public int IngredientId { get; set; }
        public int DesertId { get ; set; }

        public int ExtraSnackId{ get; set; }
        public int ExtraSauceId{ get; set; }
    }
}
