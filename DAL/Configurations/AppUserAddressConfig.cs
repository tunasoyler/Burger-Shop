using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class AppUserAddressConfig : IEntityTypeConfiguration<AppUserAddress>
    {
        public void Configure(EntityTypeBuilder<AppUserAddress> builder)
        {
           builder.HasKey(x=> new {x.AppUserId,x.userAddressId});
            builder.HasOne(x=>x.userAddress).WithMany(x=>x.AddressAppUser).HasForeignKey(x=>x.userAddressId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x=>x.appUser).WithMany(x=>x.AppUserAddress).HasForeignKey(x=>x.AppUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
