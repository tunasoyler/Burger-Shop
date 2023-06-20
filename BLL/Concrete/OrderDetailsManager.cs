﻿using BLL.Abstract;
using DAL.Abstract;
using Entity.Concrete;

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

        //public List<OrderDetails> FindByUserId(Guid Id)
        //{
           
        //        using var c = new BurgerContext();
        //        List<OrderDetails> list = c.OrderDetails.Where(x => x.Order.AppUserId == Id).ToList();
        //        return list;
        //}

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
