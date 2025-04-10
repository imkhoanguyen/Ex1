using Ex1.Dtos;
using Ex1.Entities;

namespace Ex1.Data.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetBooksWithFilterAsync(BookFilterRequest request);
    }
}