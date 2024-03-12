using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext context)
        {
            dbContext = context;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.Url,
                Description = model.Description,
                Rating = decimal.Parse(model.Rating),
                CategoryId = model.CategoryId
            };

            await dbContext.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            bool alreadyAdded = await dbContext.IdentityUsersBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (alreadyAdded == false)
            {
                var userBook = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id
                };

                await dbContext.IdentityUsersBooks.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBookAsync()
        {
            return await dbContext.Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await dbContext.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AllBookViewModel>> GetMineBookAsync(string userId)
        {
            return await dbContext.IdentityUsersBooks
                .Where(ub => ub.CollectorId == userId)
              .Select(b => new AllBookViewModel
              {
                  Id = b.Book.Id,
                  Title = b.Book.Title,
                  Author = b.Book.Author,
                  ImageUrl = b.Book.ImageUrl,
                  Description = b.Book.Description,
                  Category = b.Book.Category.Name
              })
              .ToListAsync();
        }

        public async Task<AddBookViewModel> GetNewAddBookModelAsync()
        {
            var categories = await dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            var model = new AddBookViewModel
            {
                Categories = categories
            };

            return model;
        }

        public async Task RemoveBookToCollectionAsync(string userId, BookViewModel book)
        {
            var userBook = await dbContext.IdentityUsersBooks
                     .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (userBook != null)
            {
                dbContext.IdentityUsersBooks.Remove(userBook);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
