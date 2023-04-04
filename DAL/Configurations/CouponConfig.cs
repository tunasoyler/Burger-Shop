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
    public class CouponConfig : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CouponCode).IsRequired().HasMaxLength(20);

            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Coupon)
                .HasForeignKey(o => o.CouponId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
