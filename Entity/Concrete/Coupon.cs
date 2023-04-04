﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Coupon : BaseEntity
    {
        public string CouponCode { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Coupon()
        {
            Orders= new HashSet<Order>();
        }
    }
}
