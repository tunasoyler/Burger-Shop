using BLL.Abstract;
using DAL.Abstract;
using DAL.Context;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.Concrete
{
    public class ExtraManager :IExtraService
    {
        IExtra _extradal;

        public ExtraManager(IExtra extradal)
        {
            _extradal = extradal;

        }

        public List<Extra> GetList()
        {
            return _extradal.List();
            
        }

        public bool ExtraAdd(Extra extradal)
        {
            bool IsTrue = _extradal.Insert(extradal);
            return IsTrue;
        }

       

        public Extra FindById(int id)
        {
            return _extradal.Find(id);
        }

        public bool ExtraRemove(Extra extradal)
        {
            bool IsTrue = _extradal.Delete(extradal);
            return IsTrue;
        }

        public bool ExtraUpdate(Extra extradal)
        {
            bool IsTrue = _extradal.Update(extradal);
            return IsTrue;
        }

        public List<SelectListItem> FillExtraCategory()
        {
            using var c = new BurgerContext();
            List<SelectListItem> classLevelList = c.ExtraCategories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return classLevelList;
        }
    }
}
