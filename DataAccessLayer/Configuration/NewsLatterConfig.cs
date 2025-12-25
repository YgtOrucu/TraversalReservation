using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configuration
{
    public class NewsLatterConfig : IEntityTypeConfiguration<NewsLatter>
    {
        public void Configure(EntityTypeBuilder<NewsLatter> builder)
        {
            builder.HasKey(x => x.NewsLatterID);
            builder.Property(x => x.NewsLatterID).UseIdentityColumn(1, 1);

            builder.Property(x => x.Mail).HasColumnType("varchar").HasMaxLength(30).IsRequired();      
        }
    }
}
