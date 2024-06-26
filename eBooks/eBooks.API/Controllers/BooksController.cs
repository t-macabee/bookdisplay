using eBooks.API.Data;
using eBooks.API.DTOs;
using eBooks.API.Entities;
using eBooks.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eBooks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService service;

        public BooksController(IBooksService service)
        {
           this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksDto>>> GetBooks()
        {
            var result = await service.GetBooks();
            return Ok(result);
        }
    }
}

