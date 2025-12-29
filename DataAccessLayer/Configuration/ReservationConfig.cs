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
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");

            builder.HasKey(x => x.ReservationID);
            builder.Property(x => x.ReservationID).UseIdentityColumn(1, 1);

            builder.Property(x => x.PersonCount).HasColumnType("varchar").HasMaxLength(3);
            builder.Property(x => x.Date).HasColumnType("date");
            builder.Property(x => x.Description).HasColumnType("varchar").HasMaxLength(250);
            builder.Property(x => x.Status).HasColumnType("varchar").HasMaxLength(30);
        }
    }
}
