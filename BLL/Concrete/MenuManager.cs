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
    public class MenuManager:IMenuService
    {
        IMenu _menudal;

        public MenuManager(IMenu menudal)
        {
            _menudal = menudal;
        }

        public List<Menu> GetList()
        {
            return _menudal.List();
        }

        public void MenuAdd(Menu menudal)
        {
            _menudal.Insert(menudal);
        }

       
    }
}
