using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IMenuService
    {
        List<Menu> GetList();
        public bool MenuAdd(Menu menudal);
        public Menu FindById(int id);
        public bool MenuRemove(Menu menudal);
        public bool MenuUpdate(Menu menudal);
    }
}
