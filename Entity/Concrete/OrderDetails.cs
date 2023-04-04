using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class OrderDetails 
    {
        public int Id { get; set; }
        public Order order { get; set; }
        public int OrderId { get; set; }
        public Menu menu { get; set; }
        public int MenuId { get; set; }
        public Beverage beverage { get; set; }
        public int BeverageId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }
        public Desert desert { get; set; }  
        public int DesertId { get ; set; }
        public ExtraSnack ExtraSnack { get; set; }
        public int ExtraSnackId{ get; set; }
        public ExtraSauce ExtraSauce { get; set; }
        public int ExtraSauceId{ get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; } 
    }
}
