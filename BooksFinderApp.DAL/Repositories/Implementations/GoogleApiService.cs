using BooksFinderApp.DAL.Repositories.Interfaces;

namespace BooksFinderApp.DAL.Repositories.Implementations;

public class GoogleApiService(HttpClient _client) : IGoogleApiService
{
    public async Task<string> SearchBooksAsync(string query)
    {
        string apiKey = Environment.GetEnvironmentVariable("API_KEY");
        var response = await _client.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={query}&key={apiKey}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}