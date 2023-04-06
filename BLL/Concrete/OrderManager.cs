using BLL.Abstract;
using DAL.Abstract;
using DAL.EntityFramework;
using Entity.Concrete;

namespace MVC.Controllers
{
    public class OrderManager : IOrderService
    {
        IOrder _orderdal;

        public OrderManager(IOrder orderdal)
        {
            _orderdal = orderdal;
        }

        public Order FindById(int id)
        {
            return _orderdal.Find(id);
        }

        public List<Order> GetList()
        {
            return _orderdal.List();
        }

        public bool OrderAdd(Order orderdal)
        {
            bool IsTrue = _orderdal.Insert(orderdal);
            return IsTrue;
        }

        public bool OrderRemove(Order orderdal)
        {
            bool IsTrue = _orderdal.Delete(orderdal);
            return IsTrue;
        }

        public bool OrderUpdate(Order orderdal)
        {
            bool IsTrue = _orderdal.Update(orderdal);
            return IsTrue;
        }
    }
}