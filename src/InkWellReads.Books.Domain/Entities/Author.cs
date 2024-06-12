using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InkWellReads.Books.Domain.Entities
{
    [Table("Authors")]
    public class Author : BaseEntity<string>
    {
        public Author()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
