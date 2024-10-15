namespace BooksFinderApp.DAL.Repositories.Interfaces;

public interface IGoogleApiService
{
    Task<string> SearchBooksAsync(string query);
}