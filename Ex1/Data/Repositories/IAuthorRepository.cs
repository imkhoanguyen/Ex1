using Ex1.Entities;

namespace Ex1.Data.Repositories
{
    public interface IAuthorRepository : IRepository<Authors>
    {
        Task<IEnumerable<Authors>> GetAllAuthorAsync();
        Task<Authors?> GetAuthorByIdAsync(int id);
    }
}