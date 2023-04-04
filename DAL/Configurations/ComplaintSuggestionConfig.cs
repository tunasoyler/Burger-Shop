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
    public class ComplaintSuggestionConfig : IEntityTypeConfiguration<ComplaintSuggestion>
    {
        public void Configure(EntityTypeBuilder<ComplaintSuggestion> builder)
        {
            builder
                .HasKey(x => x.Id);
        }
    }
}
