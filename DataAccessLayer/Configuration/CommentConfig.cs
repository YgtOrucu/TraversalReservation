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
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");

            builder.HasKey(x => x.CommentID);
            builder.Property(x => x.CommentID).UseIdentityColumn(1, 1);

            builder.Property(x => x.UserName).IsRequired().HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.Date).HasColumnType("date");
            builder.Property(x => x.Content).IsRequired().HasColumnType("varchar").HasMaxLength(250);
        }
    }
}
