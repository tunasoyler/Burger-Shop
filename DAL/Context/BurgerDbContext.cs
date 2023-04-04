using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVC.Models.Context
{
    public class BurgerDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<ExtraCategory> ExtraCategories { get; set; }
        public DbSet<ComplaintSuggestion> ComplaintSuggestions { get; set; }

        public BurgerDbContext(DbContextOptions<BurgerDbContext> dbContext) : base(dbContext)
        {

        }
    }
}


