using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class UserAddressConfig : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.Property(u => u.AddressLine).IsRequired().HasMaxLength(100);
            builder.Property(u => u.City).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Country).IsRequired().HasMaxLength(50);

            builder.HasMany(x => x.AddressAppUser).WithOne(x => x.userAddress).HasForeignKey(x => x.userAddressId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
