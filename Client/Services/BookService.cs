using BlazorSignalR.Shared.Models;
using System.Net.Http.Json;

namespace BlazorSignalR.Client.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Book[]> GetBooks()
        {
            return await _httpClient.GetFromJsonAsync<Book[]>("api/books/getbooks");
           
        }
        public async Task<Book> GetBookById(string id)
        {
            return await _httpClient.GetFromJsonAsync<Book>($"api/books/getbook/{id}");
        }
        public async Task<Book> AddBook(Book book)
        {
            var response = await _httpClient.PostAsJsonAsync("api/books/addbook", book);
            if (response.IsSuccessStatusCode)
            {
                return book;
            }
            return null;
        }
        public async Task<Book> UpdateBook(Book book)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/books/updatebook/{book.Id}", book);
            if (response.IsSuccessStatusCode)
            {
                return book;
            }
            return null;
        }
        public async Task<bool> DeleteBook(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/books/deletebook/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    } 
}
