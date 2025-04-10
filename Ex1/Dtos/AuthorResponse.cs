namespace Ex1.Dtos
{
    public class AuthorResponse
    {
        public int AuthorId { get; set; }
        public required string Name { get; set; }
        public required string Bio { get; set; }
    }
}
