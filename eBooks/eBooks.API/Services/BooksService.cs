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

        public async Task<List<BooksDto>> GetBooks(int? page, int? pageSize)
        {
            IQueryable<Books> query = context.Books.Include(x => x.Comments);

            query = query.OrderBy(x => x.Id);

            if(page.HasValue && pageSize.HasValue)
            {
                int pageNumber = Math.Max(page ?? 1, 1);
                int size = Math.Max(pageSize ?? 9, 1);

                query = query.Skip((pageNumber - 1) * size).Take(size);
            }

            var books = await query.ToListAsync();

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
