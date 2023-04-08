using Entity.Concrete;

namespace MVC.Models
{
    public class MenuVM
    {
        public List<Menu> MenuList { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
    }
}
