using BooksFinderApp.BLL.DTO;
using BooksFinderApp.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksFinderApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(IBookService _bookService) : ControllerBase
{
    [HttpGet("search")]
    public async Task<ActionResult<List<BookDto>>> SearchBooks([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Query cannot be empty.");
        }

        var books = await _bookService.SearchBooksAsync(query);
        return Ok(books);
    }
}