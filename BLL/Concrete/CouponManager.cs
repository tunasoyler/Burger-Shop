using BLL.Abstract;
using DAL.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class CouponManager : ICouponService
    {
        ICoupon _s;
        public CouponManager(ICoupon s)
        {
            _s = s;
        }
        public bool CouponAdd(Coupon c)
        {
            bool IsTrue = _s.Insert(c);
            return IsTrue;
        }

        public bool CouponRemove(Coupon c)
        {
            bool IsTrue = _s.Delete(c);
            return IsTrue;
        }

        public bool CouponUpdate(Coupon c)
        {
            bool IsTrue = _s.Update(c);
            return IsTrue;
        }

        public Coupon FindById(int id)
        {
            return _s.Find(id);
        }

        public List<Coupon> GetList()
        {
            return _s.List();
        }
    }
}
