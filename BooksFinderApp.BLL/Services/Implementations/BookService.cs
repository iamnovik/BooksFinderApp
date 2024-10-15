using BooksFinderApp.BLL.DTO;
using BooksFinderApp.BLL.Services.Interfaces;
using BooksFinderApp.DAL.Repositories.Interfaces;
using Newtonsoft.Json;

namespace BooksFinderApp.BLL.Services.Implementations;

public class BookService(IGoogleApiService _googleApiService) : IBookService
{
    public async Task<List<BookDto>> SearchBooksAsync(string query)
    {
        var jsonResult = await _googleApiService.SearchBooksAsync(query);
        var books = JsonConvert.DeserializeObject<GoogleApiResponse>(jsonResult);
        
        var bookDtos = new List<BookDto>();
        foreach (var item in books.Items)
        {
            bookDtos.Add(new BookDto
            {
                Title = item.VolumeInfo.Title,
                Author = string.Join(", ", item.VolumeInfo.Authors),
                PublishedDate = item.VolumeInfo.PublishedDate,
                PictureUrl = item.VolumeInfo.ImageLinks?.Thumbnail,
                InfoLink = item.VolumeInfo.InfoLink
            });
        }

        return bookDtos;
    }
}