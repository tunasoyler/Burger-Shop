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
    public class OrderDetailsManager : IOrderDetailsService
    {
        IOrderDetails _orderDetailsdal;

        public OrderDetailsManager(IOrderDetails orderDetailsdal)
        {
            _orderDetailsdal = orderDetailsdal;
        }

        public OrderDetails FindById(int id)
        {
            return _orderDetailsdal.Find(id);
        }

        public List<OrderDetails> GetList()
        {
            return _orderDetailsdal.List();
        }

        public bool OrderDetailsAdd(OrderDetails orderDetailsdal)
        {
            bool IsTrue = _orderDetailsdal.Insert(orderDetailsdal);
            return IsTrue;
        }

        public bool OrderDetailsRemove(OrderDetails orderDetailsdal)
        {
            bool IsTrue = _orderDetailsdal.Delete(orderDetailsdal);
            return IsTrue;
        }

        public bool OrderDetailsUpdate(OrderDetails orderDetailsdal)
        {
            bool IsTrue = _orderDetailsdal.Update(orderDetailsdal);
            return IsTrue;
        }
    }
}
