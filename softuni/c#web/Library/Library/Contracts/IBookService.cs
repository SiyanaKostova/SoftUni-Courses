using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBookAsync();
        Task<IEnumerable<AllBookViewModel>> GetMineBookAsync(string userId);
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task AddBookToCollectionAsync(string userId, BookViewModel book);
        Task RemoveBookToCollectionAsync(string userId, BookViewModel book);
        Task<AddBookViewModel> GetNewAddBookModelAsync();
        Task AddBookAsync(AddBookViewModel model);
    }
}
