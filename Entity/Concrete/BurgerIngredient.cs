using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class BurgerIngredient
    {
        public Burger Burger { get; set; }
        public int BurgerId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }

    }
}
