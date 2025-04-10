using Ex1.Entities;

namespace Ex1.Data.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllAuthorAsync();
        Task<Author?> GetAuthorByIdAsync(int id);
    }
}