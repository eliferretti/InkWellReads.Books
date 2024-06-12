namespace InkwellReads.Books.Application.Dto
{
    public struct BookDto
    {
        public string Title { get; set; }
        public AuthorDto Author { get; set; }
        public CategoryDto Category { get; set; }
        public string Synopsis { get; set; }
        public string Isbn { get; set; }
    }
}
