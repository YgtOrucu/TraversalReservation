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
    public class GuideConfig : IEntityTypeConfiguration<Guide>
    {
        public void Configure(EntityTypeBuilder<Guide> builder)
        {
            builder.HasKey(x => x.GuideID);
            builder.Property(x => x.GuideID).UseIdentityColumn(1, 1);

            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Description).HasColumnType("varchar").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Image).HasColumnType("varchar").HasMaxLength(250).IsRequired();
            builder.Property(x => x.TwitterUrl).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.InstagramUrl).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        }
    }
}
