using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IExtraService
    {
        List<Extra> GetList();
        public void ExtraAdd(Extra extradal);
    }
}
