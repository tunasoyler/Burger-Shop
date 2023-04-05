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
        public int Id { get; set; }
        public AppUser appUser { get; set; }
        public Guid AppUserId { get; set; }
        public UserAddress userAddress { get; set; }
        public int userAddressId { get; set; }
    }
}
