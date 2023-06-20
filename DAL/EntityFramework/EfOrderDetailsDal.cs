using DAL.Abstract;
using DAL.Concrete.Repositories;
using Entity.Concrete;

namespace DAL.EntityFramework
{
    public class EfOrderDetailsDal:GenericRepository<OrderDetails>,IOrderDetails
    {
        //public EfOrderDetailsDal(BurgerContext db) : base(db)
        //{
            
        //}
    }
}
