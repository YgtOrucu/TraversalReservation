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
    public class TestimonialConfig : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.HasKey(x => x.TestimonialID);
            builder.Property(x => x.TestimonialID).UseIdentityColumn(1, 1);

            builder.Property(x => x.Client).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Comment).HasColumnType("varchar").HasMaxLength(250).IsRequired();
            builder.Property(x => x.ClientImage).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        }
    }
}
