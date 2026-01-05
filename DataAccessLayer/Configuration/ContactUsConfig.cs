using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configuration
{
    public class ContactUsConfig : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.ToTable("ContactUs");
            builder.HasKey(x => x.ContactUsID);
            builder.Property(x => x.ContactUsID).UseIdentityColumn(1, 1);

            builder.Property(x => x.MessageBody).HasColumnType("varchar").HasMaxLength(250);
            builder.Property(x => x.Mail).HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.Subject).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.MessageDate).HasColumnType("date");
        }
    }
}
