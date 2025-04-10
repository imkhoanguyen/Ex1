using Ex1.Data.Repositories;
using Ex1.Dtos;
using Ex1.Entities;
using Ex1.Mapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Ex1.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        public async Task<IEnumerable<BookResponse>> GetAllAsync()
        {
            var books = await _bookRepo.GetAllBooksAsync();

            return books.Select(BookMapper.EntityToResponse);
        }

        public async Task<BookResponse?> GetByIdAsync(int id)
        {
            var book = await _bookRepo.GetBookByIdAsync(id);

            if (book == null) return null;

            return BookMapper.EntityToResponse(book);
        }

        public async Task<BookResponse?> CreateAsync(BookCreateRequest request)
        {
            var book = new Books
            {
                Title = request.Title,
                PublishedDate = request.PublishedDate,
                Price = request.Price,
                AuthorId = request.AuthorId,
            };

            _bookRepo.Insert(book);

            if (await _bookRepo.SaveChangesAsync())
            {
                return BookMapper.EntityToResponse(book);
            }

            return null;
        }

        public async Task<BookResponse?> UpdateAsync(BookUpdateRequest request)
        {
            var entity = await _bookRepo.GetBookByIdAsync(request.BookId);
            if (entity == null)
            {
                return null;
            }

            entity.Title = request.Title;
            entity.PublishedDate = request.PublishedDate;
            entity.Price = request.Price;
            entity.AuthorId = request.AuthorId;

            _bookRepo.Update(entity);

            if (await _bookRepo.SaveChangesAsync())
            {
                return BookMapper.EntityToResponse(entity);
            }

            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _bookRepo.GetBookByIdAsync(id);
            if (entity == null) return false;


            _bookRepo.Delete(entity);

            if (await _bookRepo.SaveChangesAsync()) return true;

            return false;
        }

        public async Task<IEnumerable<BookResponse>> GetFilterBooks(BookFilterRequest request)
        {
            var books = await _bookRepo.GetBooksWithFilterAsync(request);
            return books.Select(BookMapper.EntityToResponse);
        }
    }
}
