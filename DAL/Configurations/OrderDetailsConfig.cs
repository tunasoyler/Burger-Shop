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
    public class OrderDetailsConfig : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {

            builder.HasKey(od => new { od.MenuId, od.OrderId, od.ExtraId });

            

            builder
            .HasOne(od => od.Menu)
            .WithMany(od => od.OrderDetails)
            .HasForeignKey(od => od.MenuId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(od => od.Extra)
            .WithMany(od => od.OrderDetails)
            .HasForeignKey(od => od.ExtraId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
