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
    public class ExtraConfig : IEntityTypeConfiguration<Extra>
    {
        public void Configure(EntityTypeBuilder<Extra> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.CreatedTime).HasConversion(typeof(DateTime)).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ModifiedTime).HasConversion(typeof(DateTime)).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.ExtraCategory)
                .WithMany(c => c.Extras)
                .HasForeignKey(x => x.ExtraCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.OrderDetails)
                .WithOne(od => od.Extra)
                .HasForeignKey(od => od.ExtraId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
