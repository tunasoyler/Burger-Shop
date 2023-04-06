﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        bool Insert(T p);
        bool Update(T p);
        bool Delete(T p);
        T Find(int id);
        //List<T> List(Expression<Func<T, bool>> filter);
    }
}
