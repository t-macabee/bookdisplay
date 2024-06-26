using eBooks.API.Entities;

namespace eBooks.API.Interfaces
{
    public interface IBooksService
    {
        Task<IEnumerable<Books>> GetBooks();
    }
}
