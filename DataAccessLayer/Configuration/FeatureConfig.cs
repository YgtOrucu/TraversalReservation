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
    public class FeatureConfig : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(x => x.FeatureID);
            builder.Property(x => x.FeatureID).UseIdentityColumn(1, 1);

            builder.Property(x => x.Title).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Post1Description).HasColumnType("varchar").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Post1Image).HasColumnType("varchar").HasMaxLength(250).IsRequired();
        }
    }
}
