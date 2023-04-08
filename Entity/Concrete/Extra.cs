using Entity.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
   
    public class Extra : BaseEntity
    {
        
        public ICollection<OrderDetails> OrderDetails { get; set; }

  
        public ExtraCategory? ExtraCategory { get; set; }

        
        public int ExtraCategoryId { get; set; }
        [Required(ErrorMessage = "Fiyat alanı boş geçilemez.")]
        public decimal Price { get; set; }
        //[Required(ErrorMessage = "Açıklama alanı boş geçilemez.")]
        public string? Description { get; set; }
       
        public byte[]? Image { get; set; }
        public Extra()
        {
            OrderDetails = new List<OrderDetails>();
        }
    }
}
