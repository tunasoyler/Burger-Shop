using Entity.Concrete;
using Entity.Validations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Context
{
    //[MetadataType(typeof(AppUserValidation))]
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime MemberSince { get; set; }= DateTime.Now;
        public ICollection<Order> Orders { get; set; }
        public ICollection<AppUserAddress> AppUserAddress { get; set; }
        public AppUser()
        {
            AppUserAddress= new HashSet<AppUserAddress>();
            Orders = new HashSet<Order>();
        }
    }
}