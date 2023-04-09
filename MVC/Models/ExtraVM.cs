using Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    public class ExtraVM
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "İsim alanı boş geçilemez.")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Kategori alanı boş geçilemez.")]
        public int ExtraCategoryId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "fiyat alanı boş geçilemez.")]
        public decimal price { get; set; }


       
        public List<Extra>? Extras { get; set; }

       
        public Extra ExtraDb { get; set; }
        public List<SelectListItem>? ExtraCategoryForDropDown { get; set; }
        public ExtraVM()
        {
            Extras=new List<Extra>();
        }
        
    }
}
