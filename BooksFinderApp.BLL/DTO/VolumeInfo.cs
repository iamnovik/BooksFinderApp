namespace BooksFinderApp.BLL.DTO;

public class VolumeInfo
{
    public string Title { get; set; }
    public List<string> Authors { get; set; }
    public string PublishedDate { get; set; }
    public ImageLinks ImageLinks { get; set; }
    public string InfoLink { get; set; }
}