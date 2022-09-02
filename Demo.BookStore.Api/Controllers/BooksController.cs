using Demo.BookStore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.BookStore.Api.Controllers
{
    /// <summary>
    /// Original Source:
    /// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;

        private readonly BooksService _booksService;

        public BooksController(ILogger<BooksController> logger, BooksService booksService)
        {
            _logger = logger;
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<List<Book>> Get() => await _booksService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book newBook)
        {
            await _booksService.CreateAsync(newBook);

            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Book updatedBook)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedBook.Id = book.Id;

            await _booksService.UpdateAsync(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _booksService.RemoveAsync(id);

            return NoContent();
        }

    }
}