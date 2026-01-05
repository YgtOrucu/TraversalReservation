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
    public class AnnouncementConfig : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("Announcement");

            builder.HasKey(x => x.AnnouncementID);
            builder.Property(x => x.AnnouncementID).UseIdentityColumn(1, 1);

            builder.Property(x => x.Title).IsRequired().HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.Content).IsRequired().HasColumnType("varchar").HasMaxLength(150);
            builder.Property(x => x.Date).IsRequired().HasColumnType("date");
        }
    }
}
