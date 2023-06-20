using DAL.Abstract;
using DAL.Concrete.Repositories;
using Entity.Concrete;

namespace DAL.EntityFramework
{
    public class EfCouponDal:GenericRepository<Coupon>,ICoupon
    {
        
    }
}
