using Ex1.Dtos;
using Ex1.Entities;

namespace Ex1.Data.Repositories
{
    public interface IBookRepository : IRepository<Books>
    {
        Task<IEnumerable<Books>> GetAllBooksAsync();
        Task<Books?> GetBookByIdAsync(int id);
        Task<IEnumerable<Books>> GetBooksWithFilterAsync(BookFilterRequest request);
    }
}