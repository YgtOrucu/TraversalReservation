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
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.ContactID);
            builder.Property(x => x.ContactID).UseIdentityColumn(1, 1);

            builder.Property(x => x.Description).HasColumnType("varchar").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Mail).HasColumnType("varchar").HasMaxLength(25).IsRequired();
            builder.Property(x => x.Address).HasColumnType("varchar").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Phone).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(x => x.MapLocation).HasColumnType("varchar").HasMaxLength(250).IsRequired();
        }
    }
}
