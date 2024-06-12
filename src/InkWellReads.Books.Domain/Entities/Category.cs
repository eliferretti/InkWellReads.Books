using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InkWellReads.Books.Domain.Entities
{
    [Table("Categories")]
    public class Category : BaseEntity<string>
    {
        public Category() {
            Id = Guid.NewGuid().ToString();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
