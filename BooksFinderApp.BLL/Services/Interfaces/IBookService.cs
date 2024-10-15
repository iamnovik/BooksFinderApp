using BooksFinderApp.BLL.DTO;

namespace BooksFinderApp.BLL.Services.Interfaces;

public interface IBookService
{
    Task<List<BookDto>> SearchBooksAsync(string query);
}