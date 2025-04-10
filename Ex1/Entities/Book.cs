using System.ComponentModel.DataAnnotations;

namespace Ex1.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [MaxLength(200)]
        public required string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
