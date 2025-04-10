using Ex1.Dtos;
using Ex1.Entities;

namespace Ex1.Mapper
{
    public class BookMapper
    {
        public static BookResponse EntityToResponse(Books entity)
        {
            return new BookResponse
            {
                BookId = entity.BookId,
                Title = entity.Title,
                Price = entity.Price,
                PublishedDate = entity.PublishedDate,
                AuthorId = entity.AuthorId,
            };
        }
    }
}
