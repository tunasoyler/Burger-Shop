using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder
            .HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.Restrict); 

            builder
            .HasOne(o => o.Coupon)
            .WithMany()
            .HasForeignKey(o => o.CouponId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(o => o.User)
            .WithMany()
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
