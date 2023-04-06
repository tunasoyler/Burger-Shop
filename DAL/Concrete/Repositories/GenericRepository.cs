using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public void Insert(T p)
        {
            using var c = new BurgerContext();
            c.Add(p);
            c.SaveChanges();
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



        public void Update(T p)
        {
            using var c = new BurgerContext();
            c.SaveChanges();
        }
    }
}
