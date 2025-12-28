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
            builder.Property(x => x.ImgUrl).HasColumnType("varchar").HasMaxLength(250);
            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.Surname).HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.Gender).HasColumnType("varchar").HasMaxLength(5);
        }
    }
}
