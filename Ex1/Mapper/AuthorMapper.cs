using Ex1.Dtos;
using Ex1.Entities;

namespace Ex1.Mapper
{
    public class AuthorMapper
    {
        public static AuthorResponse EntityToResponse(Author entity)
        {
            return new AuthorResponse
            {
                AuthorId = entity.AuthorId,
                Name = entity.Name,
                Bio = entity.Bio,
            };
        }
    }
}
