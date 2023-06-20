using DAL.Abstract;
using DAL.Context;

namespace DAL.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        //BurgerContext _db;
        // DbSet<T> _object;
        // public GenericRepository()
        // {
        //     _object = _db.Set<T>();
        // }

        


        public bool Delete(T p)
        {
            using var c = new BurgerContext();
            c.Remove(p);
            int IsTrue = c.SaveChanges();
            if (IsTrue==0)
                return false;
            else
                return true;
        }

        public T Find(int id)
        {
            using var c = new BurgerContext();
           return c.Find<T>(id);
        }

        public bool Insert(T p)
        {
            using var c = new BurgerContext();
            c.Add(p);
            int IsTrue = c.SaveChanges();
            if (IsTrue == 0)
                return false;
            else
                return true;
        }



        public List<T> List()
        {
            using var c = new BurgerContext();
            return c.Set<T>().ToList();
        }



        //public List<T> List(Expression<Func<T, bool>> filter)
        //{
        //    return _object.Where(filter).ToList();
        //}



        public bool Update(T p)
        {
            using var c = new BurgerContext();
            c.Update(p);
            int IsTrue = c.SaveChanges();
            if (IsTrue == 0)
                return false;
            else
                return true;
        }
    }
}
