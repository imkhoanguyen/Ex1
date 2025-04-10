using Ex1.Dtos;

namespace Ex1.Services
{
    public interface IAuthorService
    {
        Task<AuthorResponse?> CreateAsync(AuthorCreateRequest request);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<AuthorResponse>> GetAllAsync();
        Task<AuthorResponse?> GetByIdAsync(int id);
        Task<AuthorResponse?> UpdateAsync(AuthorUpdateRequest request);
    }
}