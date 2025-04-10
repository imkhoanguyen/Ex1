using Ex1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ex1.Data.Repositories
{
    public class AuthorRepository : Repository<Authors>, IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Authors>> GetAllAuthorAsync()
        {
            return await _context.Authors.FromSqlRaw("EXEC sp_GetAllAuthors").ToListAsync();

        }

        public async Task<Authors?> GetAuthorByIdAsync(int id)
        {
            var result = await _context.Authors.FromSqlRaw($"EXEC sp_GetAuthorById {id}").ToListAsync();

            return result.FirstOrDefault();
        }
    }
}
