using Entity.Concrete;
using Microsoft.AspNetCore.Identity;

namespace MVC.Models.Context
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool State { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime MemberSince { get; set; }
        public ICollection<Order> Orders { get; set; }
        public AppUser()
        {
            Orders = new HashSet<Order>();
        }
    }
}