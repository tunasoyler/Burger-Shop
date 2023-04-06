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
    public class ExtraCategoryManager : IExtraCategoryService
    {
        IExtraCategory _s;

        public ExtraCategoryManager(IExtraCategory s)
        {
            _s = s;
        }
        public bool ExtraCategoryAdd(ExtraCategory p)
        {

            bool IsTrue = _s.Insert(p);
            return IsTrue;
        }

        public bool ExtraCategoryRemove(ExtraCategory p)
        {
            bool IsTrue = _s.Delete(p);
            return IsTrue;
        }

        public bool ExtraCategoryUpdate(ExtraCategory p)
        {
            bool IsTrue = _s.Update(p);
            return IsTrue;
        }

        public ExtraCategory FindById(int id)
        {
            return _s.Find(id);
        }

        public List<ExtraCategory> GetList()
        {
            return _s.List();
        }
    }
}
