using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class UserAddressConfig : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.Property(u => u.AddressLine).IsRequired().HasMaxLength(100);
            builder.Property(u => u.City).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Country).IsRequired().HasMaxLength(50);
        }
    }
}
