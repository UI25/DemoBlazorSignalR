using BlazorSignalR.Shared.Models;

namespace BlazorSignalR.Client.Services
{
    public interface IBookService
    {
        Task<Book[]> GetBooks();
        Task<Book> GetBookById(string id);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<bool> DeleteBook(string id);
    }
}
