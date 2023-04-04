using Entity.Concrete;
using Microsoft.AspNetCore.Identity;

namespace MVC.Models.Context
{
    public class AppUser : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
        public AppUser()
        {
            Orders = new HashSet<Order>();
        }
    }
}