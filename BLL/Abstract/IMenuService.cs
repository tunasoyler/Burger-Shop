﻿using Entity.Concrete;
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
        public void MenuAdd(Menu menudal);
    }
}
