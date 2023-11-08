using DF_Async.Models;

namespace DF_Async.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(int id);

        Task<int> AddBook(Book book);
        Task<int> UpdateBook(Book book);
        Task<int> DeleteBook(int id);



    }
}
