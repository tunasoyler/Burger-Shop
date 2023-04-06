using Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class ExtraVM
    {
      public  List<Extra> Extras { get; set; }
        public Extra ExtraDb { get; set; }
        public List<SelectListItem> ExtraCategoryForDropDown { get; set; }
        public ExtraVM()
        {
            Extras=new List<Extra>();
        }
        
    }
}
