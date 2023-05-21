namespace BookShop.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string? AgeRestriction { get; set; }
        public Guid AuthorId { get; set; }
        public int? Copies { get; set; }
        public string? Description { get; set; }
        public string? EditionType { get; set; }
        public int? Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Title { get; set; }

        public Author? Author { get; set; }

        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
