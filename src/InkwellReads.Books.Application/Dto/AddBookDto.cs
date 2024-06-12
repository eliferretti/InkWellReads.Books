namespace InkwellReads.Books.Application.Dto
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string CategoryId { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Synopsis { get; set; }
        public string Isbn { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
    }
}
