using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Models;
using _05.EF___Advanced_Quering.Seeding;

namespace _05.EF___Advanced_Quering.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorId);

            builder.Property(a => a.FirstName)
                .IsRequired(false)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.HasData(Seeder.Authors);
        }
    }
}
