using eBooks.API.Data;
using eBooks.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eBooks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly DataContext _context;

        public BooksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {  
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Books newBook)
        {
            if (newBook == null)
            {
                return BadRequest("Book data is null.");
            }

            newBook.Id = 0;

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            var createdBook = await _context.Books.FindAsync(newBook.Id);

            return CreatedAtAction(nameof(AddBook), new { id = createdBook.Id }, createdBook);
        }
    }
}

