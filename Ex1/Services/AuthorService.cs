using Ex1.Data.Repositories;
using Ex1.Dtos;
using Ex1.Entities;
using Ex1.Mapper;

namespace Ex1.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepo = authorRepository;
        }

        public async Task<IEnumerable<AuthorResponse>> GetAllAsync()
        {
            var authors = await _authorRepo.GetAllAuthorAsync();

            return authors.Select(AuthorMapper.EntityToResponse);
        }

        public async Task<AuthorResponse?> GetByIdAsync(int id)
        {
            var author = await _authorRepo.GetAuthorByIdAsync(id);

            if (author == null) return null;

            return AuthorMapper.EntityToResponse(author);
        }

        public async Task<AuthorResponse?> CreateAsync(AuthorCreateRequest request)
        {
            var author = new Author
            {
                Name = request.Name,
                Bio = request.Bio,
            };

            _authorRepo.Insert(author);

            if (await _authorRepo.SaveChangesAsync())
            {
                return AuthorMapper.EntityToResponse(author);
            }

            return null;
        }

        public async Task<AuthorResponse?> UpdateAsync(AuthorUpdateRequest request)
        {
            var entity = await _authorRepo.GetAuthorByIdAsync(request.AuthorId);
            if (entity == null)
            {
                return null;
            }

            entity.Bio = request.Bio;
            entity.Name = request.Name;

            _authorRepo.Update(entity);

            if (await _authorRepo.SaveChangesAsync())
            {
                return AuthorMapper.EntityToResponse(entity);
            }

            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _authorRepo.GetAuthorByIdAsync(id);
            if (entity == null) return false;


            _authorRepo.Delete(entity);

            if (await _authorRepo.SaveChangesAsync()) return true;

            return false;
        }
    }
}
