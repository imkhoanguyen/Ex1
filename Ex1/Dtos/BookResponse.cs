using Ex1.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ex1.Dtos
{
    public class BookResponse
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int AuthorId { get; set; }
    }
}
