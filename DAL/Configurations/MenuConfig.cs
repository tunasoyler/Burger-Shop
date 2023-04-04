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
    public class MenuConfig : IEntityTypeConfiguration<Menu>
    {
        public static byte[] ReadFile(string sPath)
        {
            byte[] data = null;

            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fStream);

            data = br.ReadBytes((int)numBytes);
            fStream.Close();
            br.Close();
            return data;
        }

        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.CreatedTime).HasConversion(typeof(DateTime)).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ModifiedTime).HasConversion(typeof(DateTime)).HasDefaultValue(DateTime.Now);

        }
    }
}
