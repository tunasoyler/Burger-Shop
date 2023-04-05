using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class UserAddress
    {
        public bool State { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<AppUserAddress> AddressAppUser { get; set; }
        public UserAddress()
        {
            AddressAppUser = new HashSet<AppUserAddress>();
        }
    }
}
