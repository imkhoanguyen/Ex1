using System.Data.SqlTypes;
using Ex1.Dtos;
using Ex1.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Ex1.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.FromSqlRaw("EXEC sp_GetAllBooks").ToListAsync();

        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            var result = await _context.Books.FromSqlRaw($"EXEC sp_GetBookById {id}").ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Book>> GetBooksWithFilterAsync(BookFilterRequest request)
        {
            var parameters = new[]
            {
                new SqlParameter("@SearchKey", (object?)request.SearchKey ?? DBNull.Value),
                new SqlParameter("@AuthorId", (object?)request.AuthorId ?? DBNull.Value),
                new SqlParameter("@FromDate", request.FromPublishedDate.HasValue && request.FromPublishedDate.Value > SqlDateTime.MinValue.Value
                    ? request.FromPublishedDate.Value
                    : DBNull.Value),
                new SqlParameter("@ToDate", request.ToPublishedDate.HasValue && request.ToPublishedDate.Value > SqlDateTime.MinValue.Value
                    ? request.ToPublishedDate.Value
                    : DBNull.Value),
                new SqlParameter("@PageSize", request.PageSize),
                new SqlParameter("@PageIndex", request.PageIndex)
            };

            return await _context.Books.FromSqlRaw("EXEC sp_FilterBooks @SearchKey, @AuthorId, @FromDate, @ToDate, @PageSize, @PageIndex", parameters).ToListAsync();
        }
    }
}
