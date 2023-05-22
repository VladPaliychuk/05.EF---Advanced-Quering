using BookShop.Models.Enums;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.Design;
using static System.Reflection.Metadata.BlobBuilder;
namespace _05.EF___Advanced_Quering
{
    public class BookShopRepository
    {
        private readonly BookShopContext _context;
        public BookShopRepository(BookShopContext context)
        {
            _context = context;
        }

        // -1-
        public async Task<List<Book>> GetBooksByAgeRestriction(string ageRestriction)
        {
            var result = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.AgeRestriction == ageRestriction)
                .ToListAsync();

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        // -2-
        public async Task<List<string>> GetGoldenBooks()
        {
            var books = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.EditionType == "Gold")
                .ToListAsync();

            var result = new List<string>();

            foreach(var book in books)
            {
                result.Add(book.Title);
            }

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        // -3-
        public async Task<List<Book>> GetBooksByPrice()
        {
            var result = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToListAsync();

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        // -4-
        public async Task<List<Book>> GetBooksNotReleasedIn(int year)
        {
            var result = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.ReleaseDate.Year != year)
                .ToListAsync();

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        // -5-
        public async Task<List<Book>> GetBooksByCategory(List<string> categories)
        {
            List<Guid> categoriesId = new List<Guid>();

            for (int i = 0; i < categories.Count; i++)
            {
                var result = await _context
                    .Categories
                    .Where(c => c.Name == categories[i])
                    .Select(c => c.CategoryId)
                    .ToListAsync();

                categoriesId.AddRange(result);
            }

            List<BookCategory> bookCategories = new List<BookCategory>();

            if (categoriesId.Count != 0)
                for (int i = 0; i < categoriesId.Count; i++)
                {
                    var result = await _context
                        .BookCategories
                        .Where(bc => bc.CategoryId == categoriesId[i])
                        .ToListAsync();

                    bookCategories.AddRange(result);
                }

            List<Book> books = new List<Book>();

            if (bookCategories.Count > 0)
                for (int i = 0; i < bookCategories.Count; i++)
                {
                    var result = await _context
                        .Books
                        .Where(b => b.BookId == bookCategories[i].BookId)
                        .ToListAsync();

                    books.AddRange(result);
                }

            if (books is not null) { return books.ToList(); }
            else { throw new NullReferenceException(); }
        }

        // -6-
        public async Task<List<Book>> GetBooksReleasedBefore(DateTime date)
        {
            var result = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.ReleaseDate < date)
                .ToListAsync();

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        // -7-
        public async Task<List<string>> GetAuthorNamesEndingIn(string input)
        {
            var authors = await _context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .AsNoTracking()
                .ToListAsync();

            var result = new List<string>();

            foreach (var author in authors)
            {
                result.Add(author.FirstName + " " + author.LastName);
            }

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        // -8-
        public async Task<List<string>> GetBookTitlesContaining(string input)
        {
            var books = await _context
                .Books
                .AsNoTracking()
                .ToListAsync();

            var result = new List<string>();
            foreach(var book in books)
            {
                if (book.Title.Contains(input))
                {
                    result.Add(book.Title.ToString());
                }
            }

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        // -9-
        public async Task<List<string>> GetBooksByAuthor(string input)
        {
            var authors = await _context
                .Authors
                .Where(a => a.LastName.StartsWith(input))
                .AsNoTracking()
                .ToListAsync();

            var books = await _context
                .Books
                .AsNoTracking()
                .ToListAsync();

            var result = new List<string>();

            foreach(var book in books)
            {
                foreach(var author in authors)
                {
                    if (book.AuthorId == author.AuthorId)
                    {
                        result.Add($"{book.Title} ({author.FirstName} {author.LastName})");
                    }
                }
            }

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        // -10-
        public async Task<int> CountBooks(int length)
        {
            var books = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.Title.Length > length)
                .ToListAsync();

            if (books is not null) { return books.Count; }
            else { throw new NullReferenceException(); }
        }

        // -11-
        public async Task<List<string>> CountCopiesByAuthor()
        {
            var authors = await _context
                .Authors
                .AsNoTracking()
                .ToListAsync();

            var books = await _context
                .Books
                .AsNoTracking()
                .ToListAsync();

            var result = new List<string>();

            foreach(var book in books)
            {
                foreach(var author in authors)
                {
                    int copies = 0;
                    if (book.AuthorId == author.AuthorId)
                        copies = +book.Copies;

                    if (copies != 0) 
                        result.Add($"{author.FirstName} {author.LastName} - {copies}");copies = 0;
                }
            }

            if (result is not null) { return result; }
            else { throw new NullReferenceException(); }
        }

        // -12-
        public async Task<List<string>> GetTotalProfitByCategory()
        {
            var categories = await _context
                .Categories
                .AsNoTracking()
                .ToListAsync();

            var books = await _context
                .Books
                .AsNoTracking()
                .ToListAsync();

            var bookCategories = await _context
                .BookCategories
                .AsNoTracking()
                .ToListAsync();

            var result = new List<string>();

            foreach (var bc in bookCategories)
            {
                foreach (var category in categories)
                {
                    if (category.CategoryId == bc.CategoryId)
                    {
                        decimal value = 0;
                        foreach (var book in books)
                            if (book.BookId == bc.BookId)
                            {
                                decimal c = new decimal(book.Copies);
                                decimal p = book.Price;
                                value += p * c;
                            }
                        result.Add($"{category.Name} ${value}");
                    }
                }
            }

            if (result is not null) { return result; }
            else { throw new NullReferenceException(); }

        }

        // -13-
        public async Task<List<string>> GetMostRecentBooks()
        {
            var bookCategories = await _context
                .BookCategories
                .AsNoTracking()
                .ToListAsync();

            var books = await _context
                .Books
                .AsNoTracking()
                .ToListAsync();

            var result = new List<string>();

            foreach(var bc in bookCategories)
            {
                var category = await _context
                    .Categories
                    .AsNoTracking()
                    .Where(c => c.CategoryId == bc.CategoryId)
                    .FirstOrDefaultAsync();

                var mostRecentBooks = await _context
                    .Books
                    .AsNoTracking()
                    .Where(b => b.BookId == bc.BookId)
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .ToListAsync();

                result.Add($"{category.Name}: ");

                for (int i = 0; i < mostRecentBooks.Count; i++)
                {
                    result.Add($"{mostRecentBooks[i].Title} - {mostRecentBooks[i].ReleaseDate}");
                }
            }

            if (result is not null) { return result; }
            else { throw new NullReferenceException(); }
        }

        // -14-
        public async Task IncreasePrices()
        {
            var books = await _context
                .Books
                .Where(b => b.ReleaseDate.Year < 2010)
                .ToListAsync();

            books?.ForEach(x => {
                    x.Price += 5;
                });

            await _context.SaveChangesAsync();
        }

        // -15-
        public async Task<List<string>> RemoveBooks()
        {
            var booksToDelete = await _context
                .Books
                .Where(b => b.Copies < 4200)
                .ToListAsync();

            _context.Books.RemoveRange(booksToDelete);

            var result = new List<string>();
            foreach(var book in booksToDelete)
            {
                result.Add($"{book.Title} ");
            }

            if (result is not null) { return result; }
            else { throw new NullReferenceException(); }
        }
    }
}

