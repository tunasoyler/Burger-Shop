using Entity.Concrete;

namespace BLL.Abstract
{
    public interface IOrderDetailsService
    {
        List<OrderDetails> GetList();
        public bool OrderDetailsAdd(OrderDetails orderDetailsDal);
        public OrderDetails FindById(int id);
        public List<OrderDetails> FindByUserId(Guid Id);
        public bool OrderDetailsRemove(OrderDetails orderDetailsDal);
        public bool OrderDetailsUpdate(OrderDetails orderDetailsDal);
    }
}