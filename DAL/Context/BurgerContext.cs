using DAL.Configurations;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace MVC.Models.Context
{

    public class BurgerContext : IdentityDbContext<AppUser, AppRole, Guid>
    {



        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<ExtraCategory> ExtraCategories { get; set; }
        public DbSet<ComplaintSuggestion> ComplaintSuggestions { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<AppUserAddress> appUserAddress { get; set; }
        


        public BurgerContext(DbContextOptions<BurgerContext> dbContext) : base(dbContext)
        {



        }



        public BurgerContext()
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AppUserConfig())
            .ApplyConfiguration(new CouponConfig()).ApplyConfiguration(new ExtraConfig())
            .ApplyConfiguration(new MenuConfig()).ApplyConfiguration(new OrderConfig()).ApplyConfiguration(new OrderDetailsConfig()).ApplyConfiguration(new ComplaintSuggestionConfig()).ApplyConfiguration(new ExtraCategoryConfig());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {



            //Tuna
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-BVE8G4S;Database=BurgerMVCDb;Trusted_Connection=True;MultipleActiveResultSets=true");




            ////Huseyin
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=DESKTOP-FJAHODS;Database=BurgerMVCDb;Trusted_Connection=True;MultipleActiveResultSets=true");




            ////Beste
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q56AEMU\\MSSQLKD14;Database=BurgerMVCDb;User ID=sa;Password=Beste1998.");



        }

        
    }
}


