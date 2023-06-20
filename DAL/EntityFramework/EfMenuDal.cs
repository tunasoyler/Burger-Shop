using DAL.Abstract;
using DAL.Concrete.Repositories;
using Entity.Concrete;

namespace DAL.EntityFramework
{
    public class EfMenuDal:GenericRepository<Menu>,IMenu
    {
        
    }
}
