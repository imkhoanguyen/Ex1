using System.ComponentModel.DataAnnotations;

namespace Ex1.Dtos
{
    public class AuthorUpdateRequest
    {
        public int AuthorId { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public required string Bio { get; set; }
    }
}
