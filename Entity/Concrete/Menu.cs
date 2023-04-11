using Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Menu : BaseEntity
    {
        //[Required(ErrorMessage ="Fotoğraf alanı boş geçilemez.")]
        public byte[]? Image { get; set; }
        [Required(ErrorMessage = "Açıklama alanı boş geçilemez.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Fiyat alanı boş geçilemez.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Menü kategori alanı boş geçilemez.")]
        public string MenuCategory { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Menu()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

    }
}
