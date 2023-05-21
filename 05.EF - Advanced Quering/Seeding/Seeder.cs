using Bogus;
using BookShop.Models;
using BookShop.Models.Enums;

namespace _05.EF___Advanced_Quering.Seeding
{
    public static class Seeder
    {
        static Seeder()
        {
            if (Authors is null && Books is null && BookCategories is null && Categories is null)
            {
                InitializeData();
            }
        }

        public static List<Author> Authors { get; set; } = null!;
        public static List<Book> Books { get; set; } = null!;
        public static List<BookCategory> BookCategories { get; set; } = null!;
        public static List<Category> Categories { get; set; } = null!;

        private static void InitializeData()
        {
            /*Faker<Author> authorFaker = GetAuthorGenerator();
            Faker<Book> bookFaker = GetBookGenerator();
            Faker<BookCategory> bookCategoryFaker = GetBookCategoryGenerator();
            Faker<Category> categoryFaker = GetCategoryGenerator();

            List<Author> authors = authorFaker.Generate(5);
            List<Book> books = bookFaker.Generate(5);
            List<BookCategory> bookCategories = bookCategoryFaker.Generate(10);
            List<Category> categories = categoryFaker.Generate(5);

            Books.AddRange(books);
            Authors.AddRange(authors);
            BookCategories.AddRange(bookCategories);
            Categories.AddRange(categories);*/

            //Authors = GetAuthorGenerator().Generate(5);
            Books = GetBookGenerator().Generate(5);
            BookCategories = GetBookCategoryGenerator().Generate(7);
            //Categories = GetCategoryGenerator().Generate(10);
        }

        private static Faker<Author> GetAuthorGenerator()
        {
            return new Faker<Author>()
                .RuleFor(a => a.AuthorId, f => Guid.NewGuid())
                .RuleFor(a => a.FirstName, f => f.Person.FirstName)
                .RuleFor(a => a.LastName, f => f.Person.LastName);
        }
        private static Faker<Book> GetBookGenerator()
        {
            return new Faker<Book>()
                .RuleFor(b => b.BookId, f => Guid.NewGuid())
                .RuleFor(b => b.Title, f => f.Random.Words())
                .RuleFor(b => b.Description, f => f.Lorem.Text())
                .RuleFor(b => b.ReleaseDate, f => f.Date.Past(5))
                .RuleFor(b => b.Copies, f => f.Random.Int(1, 100))
                .RuleFor(b => b.Price, f => f.Random.Int(5, 300))
                .RuleFor(b => b.EditionType, f => f.Random.Enum<EditionType>().ToString())
                .RuleFor(b => b.AgeRestriction, f => f.Random.Enum<AgeRestriction>().ToString())
                .RuleFor(b => b.AuthorId, f => f.PickRandom(Authors).AuthorId);
        }
        private static Faker<Category> GetCategoryGenerator()
        {
            return new Faker<Category>()
                .RuleFor(c => c.CategoryId, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Lorem.Word());
        }
        private static Faker<BookCategory> GetBookCategoryGenerator()
        {
            return new Faker<BookCategory>()
                .RuleFor(bc => bc.BookId, f => f.PickRandom(Books).BookId)
                .RuleFor(bc => bc.CategoryId, f => f.PickRandom(Categories).CategoryId);
        }
    }
}
