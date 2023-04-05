using DAL.Abstract;
using Entity.Concrete;
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
    public class MenuRepository : IMenu
    {
        private readonly BurgerContext _db;

        public MenuRepository(BurgerContext db)
        {
            _db = db;
        }

        DbSet<Menu> _object;
        public void Delete(Menu p)
        {
            _object.Remove(p);
            _db.SaveChanges();
        }

        public void Insert(Menu p)
        {
            _object.Add(p);
            _db.SaveChanges();
        }

        public List<Menu> List()
        {
            return _object.ToList();
        }

        public List<Menu> List(Expression<Func<Menu, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Menu p)
        {
            _db.SaveChanges();
        }
    }
}
