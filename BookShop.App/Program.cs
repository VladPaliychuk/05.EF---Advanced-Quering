
using _05.EF___Advanced_Quering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var connection = "Server=.\\SQLEXPRESS;Initial Catalog=BookShop;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;";

var options = new DbContextOptionsBuilder<BookShopContext>()
                 .UseSqlServer(new SqlConnection(connection))
                 .Options;

var context = new BookShopContext(options);

var repository = new BookShopRepository(context);

Console.Write("Query (exit to close app): ");
string n = Console.ReadLine();

while (n is not "exit")
{
    switch (n)
    {
        case "1":

            Console.Write("Age restriction (Minor, Teen, Adult): ");
            string input = Console.ReadLine();

            var r1 = await repository.GetBooksByAgeRestriction(input);

            foreach(var item in r1)
            {
                Console.WriteLine($"Title: {item.Title}");
            }

            break;

        case "2":

            var r2 = await repository.GetGoldenBooks();

            foreach(var item in r2)
            {
                Console.WriteLine($"Title: {item}");
            }

            break;

        case "3":

            var r3 = await repository.GetBooksByPrice();

            foreach(var item in r3)
            {
                Console.WriteLine($"\n{item.Title} - ${item.Price}");
            }

            break;
            
        case "4":

            Console.Write("Book not released in: ");
            int year = int.Parse(Console.ReadLine());
            var r4 = await repository.GetBooksNotReleasedIn(year);

            foreach(var item in r4)
            {
                Console.WriteLine($"{item.Title}");
            }

            break;

        case "5":

            Console.Write("Categories: ");
            string categories = Console.ReadLine();
            List<string> categoriesList = categories.Split(" ").ToList();

            var r5 = await repository.GetBooksByCategory(categoriesList);

            foreach(var item in r5)
            {
                Console.WriteLine($"{item.Title}");
            }
            break;

        case "6":

            Console.Write("Books released before (dd-mm-yyyy): ");
            string date = Console.ReadLine();
            DateTime Date = DateTime.Parse(date);
            var r6 = await repository.GetBooksReleasedBefore(Date);
            foreach(var item in r6)
            {
                Console.WriteLine($"{item.Title} - {item.EditionType} - {item.Price}");
            }

            break;

        case "7":

            Console.WriteLine();
            Console.Write("Author firstname ends with: ");
            string authorName = Console.ReadLine();
            var r7 = await repository.GetAuthorNamesEndingIn(authorName);

            foreach(var item in r7)
            {
                Console.WriteLine(item);
            }

            break;

        case "8":

            Console.WriteLine();
            Console.Write("Title contains : ");
            string titleName = Console.ReadLine();
            var r8 = await repository.GetBookTitlesContaining(titleName);

            foreach(var item in r8)
            {
                Console.WriteLine(item);
            }
            break;

        case "9":

            Console.WriteLine();
            Console.Write("Author Lastname starts with (example: Kil): ");
            string lastname = Console.ReadLine();
            var r9 = await repository.GetBooksByAuthor(lastname);

            foreach(var item in r9)
            {
                Console.WriteLine(item);
            }
            break;

        case "10":

            Console.WriteLine();
            Console.Write("Length: ");
            string length = Console.ReadLine();
            var r10 = await repository.CountBooks(Convert.ToInt32(length));

            Console.WriteLine($"There are {r10} books with longer title than {length} symbols");

            break;

        case "11":

            Console.WriteLine();
            var r11 = await repository.CountCopiesByAuthor();

            foreach(var item in r11)
            {
                Console.WriteLine(item);
            }

            break;

        case "12":

            Console.WriteLine();
            var r12 = await repository.GetTotalProfitByCategory();

            foreach(var item in r12)
            {
                Console.WriteLine(item);
            }
            break;

        case "13":

            Console.WriteLine();
            var r13 = await repository.GetMostRecentBooks();

            foreach(var item in r13)
            {
                Console.WriteLine(item);
            }
            break;

        case "14":

            await repository.IncreasePrices();
            Console.WriteLine("Done!");
            break;

        case "15":

            Console.WriteLine();
            var result15 = await repository.RemoveBooks();

            Console.WriteLine($"Books deleted: {result15}");
            break;

        default:
            Console.WriteLine("\n");
            break;
    }
    Console.Write("\nQuery (exit to close app): ");
    n = Console.ReadLine();
}