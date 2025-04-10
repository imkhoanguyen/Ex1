namespace Ex1.Dtos
{
    public class BookFilterRequest
    {
        public string? SearchKey { get; set; }
        public int? AuthorId { get; set; }
        public DateTime? FromPublishedDate { get; set; }
        public DateTime? ToPublishedDate { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
