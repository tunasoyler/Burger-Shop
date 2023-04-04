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
        public AppUser User { get; set; }
        public int UserId { get; set; }
    }
}
