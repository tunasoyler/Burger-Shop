using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IOrderService
    {
        List<Order> GetList();
        public bool OrderAdd(Order c);
        public Order FindById(int id);
        public bool OrderRemove(Order c);
        public bool OrderUpdate(Order c);
    }
}
