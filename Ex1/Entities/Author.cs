﻿using System.ComponentModel.DataAnnotations;

namespace Ex1.Entities
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public required string Bio { get; set; }
        public ICollection<Book> Books { get; set; } = [];
    }
}
