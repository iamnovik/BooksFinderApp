namespace BooksFinderApp.BLL.DTO;

public class BookDto
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string PublishedDate { get; set; } = null!;
    public string? PictureUrl { get; set; }
    public string InfoLink { get; set; } = null!;
}