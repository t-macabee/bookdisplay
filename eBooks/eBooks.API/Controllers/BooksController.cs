using eBooks.API.Data;
using eBooks.API.DTOs;
using eBooks.API.Entities;
using eBooks.API.Helpers;
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
        public async Task<ActionResult<List<BooksDto>>> GetBooks(int? page = null, int? pageSize = null) 
        {
            var result = await service.GetBooks(page, pageSize);
            return Ok(result);
        }

        [HttpPost("{id}/comment")]
        public async Task<ActionResult<CommentsDto>> AddComment(int id, [FromBody] string comment)
        {
            var result = await service.AddComment(id, comment);
            return Ok(result);
        }

        [HttpPost("{id}/like")]
        public async Task<ActionResult<bool>> AddLike(int id)
        {
            var result = await service.AddLike(id);
            return Ok(result);
        }

    }
}

