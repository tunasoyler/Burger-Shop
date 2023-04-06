using BLL.Abstract;
using DAL.Abstract;
using DAL.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ExtraAdd(Extra extradal)
        {
            _extradal.Insert(extradal);
        }
    }
}
