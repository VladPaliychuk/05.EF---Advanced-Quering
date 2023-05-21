using BookShop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using _05.EF___Advanced_Quering.Seeding;

namespace _05.EF___Advanced_Quering.Configurations
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
