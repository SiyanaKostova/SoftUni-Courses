namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string input = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //int number = int.Parse(Console.ReadLine());
            Console.WriteLine(RemoveBooks(db));
            //IncreasePrices(db);

        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (!Enum.TryParse<AgeRestriction>(command, true, out var ageRestriction))
            {
                return $"{command} is not a valid type";
            }

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:f2}"));
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            if (input is null)
            {
                throw new ArgumentException(nameof(input));
            }

            string[] categories = input.Split(' ').Select(c => c.ToLower()).ToArray();

            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < parsedDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate);

            return string.Join(Environment.NewLine,
                books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}"));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName);

            return string.Join(Environment.NewLine, authors.Select(a => a.FullName));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title);

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    BookTitle = b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName
                });

            return string.Join(Environment.NewLine,
                books.Select(b => $"{b.BookTitle} ({b.AuthorName})"));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Count(b => b.Title.Length > lengthCheck);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = string.Join(" ", a.FirstName, a.LastName),
                    TotalBooks = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(b => b.TotalBooks)
                .ToList();

            return string.Join(Environment.NewLine,
               authors.Select(a => $"{a.AuthorName} - {a.TotalBooks}"));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitsByCategory = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToList();

            return string.Join(Environment.NewLine,
                profitsByCategory.Select(pc => $"{pc.CategoryName} ${pc.TotalProfit:f2}"));

        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    CatName = c.Name,
                    MostRecentBooks = c.CategoryBooks.OrderByDescending(bc => bc.Book.ReleaseDate)
                    .Take(3)
                    .Select(cb => new
                    {
                        BookTitle = cb.Book.Title,
                        cb.Book.ReleaseDate!.Value.Year
                    })
                })
                .OrderBy(c => c.CatName);

            StringBuilder sb = new StringBuilder();
            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CatName}");
                foreach (var mostRecentBook in category.MostRecentBooks)
                {
                    sb.AppendLine($"{mostRecentBook.BookTitle} ({mostRecentBook.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate!.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            context.ChangeTracker.Clear();

            var books = context.Books
                .Where(b => b.Copies < 4200);

            context.RemoveRange(books);

            return context.SaveChanges();
        }
    }
}


