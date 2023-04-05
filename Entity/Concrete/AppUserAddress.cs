using MVC.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class AppUserAddress
    {
        public AppUser appUser { get; set; }
        public int AppUserId { get; set; }
        public UserAddress userAddress { get; set; }
        public int userAddressId { get; set; }
    }
}
