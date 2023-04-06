using Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public bool ExtraAdd(Extra extradal);
        public Extra FindById(int id);
        public bool ExtraRemove(Extra extradal);
        public bool ExtraUpdate(Extra extradal);
        List<SelectListItem> FillExtraCategory();
    }
}

