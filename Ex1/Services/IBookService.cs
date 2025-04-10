using Ex1.Dtos;

namespace Ex1.Services
{
    public interface IBookService
    {
        Task<BookResponse?> CreateAsync(BookCreateRequest request);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<BookResponse>> GetAllAsync();
        Task<BookResponse?> GetByIdAsync(int id);
        Task<BookResponse?> UpdateAsync(BookUpdateRequest request);
        Task<IEnumerable<BookResponse>> GetFilterBooks(BookFilterRequest request);
    }
}