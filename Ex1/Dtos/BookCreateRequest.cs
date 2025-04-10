using System.ComponentModel.DataAnnotations;

namespace Ex1.Dtos
{
    public class BookCreateRequest
    {
        [Required]
        [MaxLength(200)]
        public required string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int AuthorId { get; set; }
    }
}
