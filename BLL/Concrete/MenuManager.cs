using BLL.Abstract;
using DAL.Abstract;
using Entity.Concrete;

namespace BLL.Concrete
{
    public class MenuManager : IMenuService
    {
        IMenu _menudal;

        public MenuManager(IMenu menudal)
        {
            _menudal = menudal;
        }

        public Menu FindById(int id)
        {
            return _menudal.Find(id);
        }

        public List<Menu> GetList()
        {
            return _menudal.List();
        }

        public bool MenuAdd(Menu menudal)
        {
            bool IsTrue = _menudal.Insert(menudal);
            return IsTrue;
        }

        public bool MenuRemove(Menu menudal)
        {
            bool IsTrue = _menudal.Delete(menudal);
            return IsTrue;
        }

        public bool MenuUpdate(Menu menudal)
        {
            bool IsTrue = _menudal.Update(menudal);
            return IsTrue;
        }

      
    }
}
