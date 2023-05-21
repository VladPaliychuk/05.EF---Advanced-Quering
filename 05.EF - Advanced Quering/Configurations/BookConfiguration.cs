using BookShop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookShop.Data.Seeding;

namespace BookShop.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);

            builder.Property(b => b.Title)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(b => b.Description)
                .HasMaxLength(1000)
                .IsUnicode(true);

            builder.Property(b => b.EditionType)
                .IsRequired();

            builder.Property(b => b.AgeRestriction)
                .IsRequired();

            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            builder.HasData(Seeder.Books);
        }
    }
}
