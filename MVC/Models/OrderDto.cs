using Entity.Concrete;

namespace MVC.Models
{
    public class OrderDto
    {
        public Menu menu { get; set; }
        public Extra extra { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
