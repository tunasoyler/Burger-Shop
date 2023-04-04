using MVC.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Order : BaseEntity
    {
        public ICollection<OrderDetails> OrderDetails { get; set; }        
        public Coupon? Coupon { get; set; }
        public int CouponId { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
        public decimal OrderTotal { get; set; }
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
    }
}
