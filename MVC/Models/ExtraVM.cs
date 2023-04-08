using Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    public class ExtraVM
    {

       
        public int ExtraCategoryId { get; set; }
        
        public decimal Price { get; set; }

       
      
        public byte[]? Image { get; set; }
        public  List<Extra> Extras { get; set; }

       
        public Extra ExtraDb { get; set; }
        public List<SelectListItem> ExtraCategoryForDropDown { get; set; }
        public ExtraVM()
        {
            Extras=new List<Extra>();
        }
        
    }
}
