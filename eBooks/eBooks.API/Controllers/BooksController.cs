using eBooks.API.Data;
using eBooks.API.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Books> GetBooks()
        {
            return _context.Books.ToList();
        }
    }
}
