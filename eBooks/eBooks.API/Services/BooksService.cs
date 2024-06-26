using AutoMapper;
using eBooks.API.Data;
using eBooks.API.DTOs;
using eBooks.API.Entities;
using eBooks.API.Helpers;
using eBooks.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eBooks.API.Services
{
    public class BooksService : IBooksService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public BooksService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<BooksDto>> GetBooks(int page, int pageSize)
        {
            var books = await context.Books
            .Include(x => x.Comments)            
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            return mapper.Map<List<BooksDto>>(books);            
        }
    

        public async Task<CommentsDto> AddComment(int id, string content)
        {
            var book = await context.Books.FindAsync(id);

            var comment = new Comments
            {
                BookId = id,
                Content = content,
            };

            book.Comments ??= new List<Comments>();
            book.Comments.Add(comment);

            await context.SaveChangesAsync();

            return mapper.Map<CommentsDto>(comment);
        }

        public async Task<bool> AddLike(int bookId)
        {
            var book = await context.Books.FindAsync(bookId);

            book.Liked = !(book.Liked ?? false);

            await context.SaveChangesAsync();

            return book.Liked ?? false;
        }

      
    }
}
