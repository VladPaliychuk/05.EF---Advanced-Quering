using BookShop.Data.Configurations;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace _05.EF___Advanced_Quering
{
    public class BookShopContext : DbContext
    {
        public BookShopContext(DbContextOptions<BookShopContext> options) : base(options) { }

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<BookCategory> BookCategories => Set<BookCategory>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BookCategoryConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=BookShop;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;");
        }
    }
}