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
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {          
            builder.Property(x => x.ImgUrl).IsRequired().HasColumnType("varchar").HasMaxLength(250);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.Surname).IsRequired().HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.Gender).IsRequired().HasColumnType("varchar").HasMaxLength(5);
        }
    }
}
