using Entity.Concrete;

namespace MVC.Models
{
    public class OrderVM
    {

        public List<OrderDto> OrderList { get; set; }
        public Order OrderDb { get; set; }
    }
}
