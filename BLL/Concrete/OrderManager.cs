using BLL.Abstract;
using DAL.Abstract;
using DAL.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrder _orderDal;

        public OrderManager(IOrder orderDal)
        {
            _orderDal = orderDal;
        }

        public Order FindById(int id)
        {
           return _orderDal.Find(id);
        }

        public List<Order> GetList()
        {
            return _orderDal.List();
        }

        public bool OrderAdd(Order c)
        {
            bool IsTrue =_orderDal.Insert(c);
            return IsTrue;
        }

        public bool OrderRemove(Order c)
        {
            bool IsTrue = _orderDal.Delete(c);
            return IsTrue;
        }

        public bool OrderUpdate(Order c)
        {
            bool IsTrue = _orderDal.Update(c);
            return IsTrue;
        }
    }
}
