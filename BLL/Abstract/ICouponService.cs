using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface ICouponService
    {
        List<Coupon> GetList();
        public bool CouponAdd(Coupon c);
        public Coupon FindById(int id);
        public bool CouponRemove(Coupon c);
        public bool CouponUpdate(Coupon c);
    }
}
