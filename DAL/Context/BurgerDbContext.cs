using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVC.Models.Context
{
    public class BurgerDbContext : IdentityDbContext
    {

        public class AppIdentityDbContext : IdentityDbContext<AppUser>
        {           

            public AppIdentityDbContext(DbContextOptions options) : base(options)
            {
            }
        }
    }
}


