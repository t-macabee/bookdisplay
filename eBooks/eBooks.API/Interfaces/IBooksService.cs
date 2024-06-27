using eBooks.API.DTOs;
using eBooks.API.Entities;
using eBooks.API.Helpers;

namespace eBooks.API.Interfaces
{
    public interface IBooksService
    {        
        Task<List<BooksDto>> GetBooks(int? page, int? pageSize);
        Task<CommentsDto> AddComment(int id, string content);        
        Task<bool> AddLike(int id);        
    }
}
