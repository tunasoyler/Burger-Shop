using Entity.Concrete;

namespace BLL.Abstract
{
    public interface IOrderService
    {
        List<Order> GetList();
        public bool OrderAdd(Order orderdal);
        public Order FindById(int id);
        public bool OrderRemove(Order orderdal);
        public bool OrderUpdate(Order orderdal);
       

    }
}