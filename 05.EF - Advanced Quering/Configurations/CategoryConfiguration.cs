using BookShop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookShop.Data.Seeding;

namespace BookShop.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.HasData(Seeder.Categories);
        }
    }
}
