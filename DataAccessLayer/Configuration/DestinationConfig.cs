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
    public class DestinationConfig : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.HasKey(x => x.DestinationID);
            builder.Property(x => x.DestinationID).UseIdentityColumn(1, 1);

            builder.Property(x => x.City).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.DayAndNight).HasColumnType("varchar").HasMaxLength(25).IsRequired();
            builder.Property(x => x.Price).HasPrecision(8, 2);
            builder.Property(x => x.Image).HasColumnType("varchar").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasColumnType("varchar").HasMaxLength(300).IsRequired();
        }
    }
}
