﻿using DAL.Abstract;
using DAL.Concrete.Repositories;
using Entity.Concrete;
using MVC.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
    public class EfCouponDal:GenericRepository<Coupon>,ICoupon
    {
        public EfCouponDal(BurgerContext db) : base(db)
        {
            
        }
    }
}
