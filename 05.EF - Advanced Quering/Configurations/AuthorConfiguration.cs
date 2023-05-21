using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookShop.Models;
using BookShop.Data.Seeding;

namespace BookShop.Data.Configurations
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
