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
        BurgerContext _db;
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = _db.Set<T>();
        }


        public void Delete(T p)
        {
            _object.Remove(p);
            _db.SaveChanges();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            _db.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            _db.SaveChanges();
        }
    }
}
