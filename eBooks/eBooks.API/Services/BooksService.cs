using AutoMapper;
using eBooks.API.Data;
using eBooks.API.Entities;
using eBooks.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eBooks.API.Services
{
    public class BooksService : IBooksService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BooksService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Books>> GetBooks()
        {
            var result = await _context.Books.Include(x => x.Comments).ToListAsync();
            return _mapper.Map<IEnumerable<Books>>(result);
        }
    }
}
