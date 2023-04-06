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
    public class ExtraCategoryConfig : IEntityTypeConfiguration<ExtraCategory>
    {
        public void Configure(EntityTypeBuilder<ExtraCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedTime).HasConversion(typeof(DateTime)).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ModifiedTime).HasConversion(typeof(DateTime)).HasDefaultValue(DateTime.Now);

            builder.HasData(
                new ExtraCategory { Id = 1, Name = "Beverage" });
            builder.HasData(
                new ExtraCategory { Id = 2, Name = "Snack" });
            builder.HasData(
                new ExtraCategory { Id = 3, Name = "Sauce" });
        }
    }
}
