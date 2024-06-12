using System.ComponentModel.DataAnnotations.Schema;

namespace InkWellReads.Books.Domain.Entities
{
    [Table("Books")]
    public class Book : BaseEntity<string>
    {
        public Book()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }
        public string AuthorId { get; set; }
        public Author Author { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Synopsis { get; set; }
        public string Isbn { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
    }
}
