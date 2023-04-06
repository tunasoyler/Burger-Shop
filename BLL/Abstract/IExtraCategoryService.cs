using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IExtraCategoryService
    {
        List<ExtraCategory> GetList();
        public bool ExtraCategoryAdd(ExtraCategory p);
        public ExtraCategory FindById(int id);
        public bool ExtraCategoryRemove(ExtraCategory p);
        public bool ExtraCategoryUpdate(ExtraCategory p);
    }
}
