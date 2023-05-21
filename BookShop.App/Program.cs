
using _05.EF___Advanced_Quering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var connection = "Server=.\\SQLEXPRESS;Initial Catalog=BookShop;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;";

var options = new DbContextOptionsBuilder<BookShopContext>()
                 .UseSqlServer(new SqlConnection(connection))
                 .Options;

var context = new BookShopContext(options);

var repository = new BookShopRepository(context);

Console.WriteLine("Welcome to Book shop!");

Console.Write("Input number to start specific query (EXIT to close app): ");
string queryNumber = Console.ReadLine();

while (queryNumber is not "EXIT")
{
    switch (queryNumber)
    {
        case "1":

            Console.WriteLine();
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
            Console.Write("Title name contains (Titlename): ");
            string titleName = Console.ReadLine();
            var result8 = await repository.GetBookTitlesContaining(titleName);

            for (int i = 0; i < result8.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result8[i]}");
                Console.ResetColor();
            }

            break;

        case "9":

            Console.WriteLine();
            Console.Write("Author Lastname starts with (Lastname): ");
            string lastname = Console.ReadLine();
            var result9 = await repository.GetBooksByAuthor(lastname);

            for (int i = 0; i < result9.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result9[i]}");
                Console.ResetColor();
            }

            break;

        case "10":

            Console.WriteLine();
            Console.Write("Length: ");
            string length = Console.ReadLine();
            var result10 = await repository.CountBooks(Convert.ToInt32(length));

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"There are {result10} books with longer title than {length} symbols");
            Console.ResetColor();

            break;

        case "11":

            Console.WriteLine();
            var result11 = await repository.CountCopiesByAuthor();

            for (int i = 0; i < result11.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result11[i]}");
                Console.ResetColor();
            }

            break;

        case "12":

            Console.WriteLine();
            var result12 = await repository.GetTotalProfitByCategory();

            for (int i = 0; i < result12.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result12[i]}");
                Console.ResetColor();
            }

            break;

        case "13":

            Console.WriteLine();
            var result13 = await repository.GetMostRecentBooks();

            for (int i = 0; i < result13.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result13[i]}");
                Console.ResetColor();
            }

            break;

        case "14":

            Console.WriteLine();
            await repository.IncreasePrices();

            Console.WriteLine("Done!");

            break;

        case "15":

            Console.WriteLine();
            var result15 = await repository.RemoveBooks();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"Books deleted: {result15}");
            Console.ResetColor();

            break;

        default:

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Wrong query number!");
            Console.ResetColor();

            break;
    }

    Console.WriteLine();
    Console.Write("Input number to start specific query (EXIT to close app): ");
    queryNumber = Console.ReadLine();
}