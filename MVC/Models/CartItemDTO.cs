using Entity.Concrete;
using Entity.Enums;
using System.Drawing.Printing;

namespace MVC.Models
{
    public class CartItemDTO
    {
        public string Name { get; set; }
        public CartDTO Cart { get; set; }
        public Menu? Menu { get; set; }
        public int? MenuId { get; set; }
        public Extra? Extra { get; set; }
        public int? ExtraId { get; set; }
        public Size Size { get; set; }
        public byte[]? Image { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
    }
}