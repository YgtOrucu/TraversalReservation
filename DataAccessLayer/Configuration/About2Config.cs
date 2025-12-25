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
    public class About2Config : IEntityTypeConfiguration<About2>
    {
        public void Configure(EntityTypeBuilder<About2> builder)
        {
            builder.ToTable("About2");

            builder.HasKey(x => x.AboutID);
            builder.Property(x => x.AboutID).UseIdentityColumn(1, 1);

            builder.Property(x => x.Title1).IsRequired().HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.Title2).IsRequired().HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.Description).IsRequired().HasColumnType("varchar").HasMaxLength(250);
            builder.Property(x => x.Image).IsRequired().HasColumnType("varchar").HasMaxLength(250);
        }
    }
}
