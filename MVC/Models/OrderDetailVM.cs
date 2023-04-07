using Entity.Concrete;

namespace MVC.Models
{
    public class OrderDetailVM
    {
        public List<OrderDetailDto> orders { get; set; }
        public OrderDetails orderDetails { get; set; }
        public OrderDetailVM()
        {
            orders = new List<OrderDetailDto>();
        }
    }
}
