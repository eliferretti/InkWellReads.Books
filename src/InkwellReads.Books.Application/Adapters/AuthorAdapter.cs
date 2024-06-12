using InkwellReads.Books.Application.Command.Authors;
using InkwellReads.Books.Application.Dto;
using InkWellReads.Books.Domain.Entities;

namespace InkwellReads.Books.Application.Adapters
{
    public class AuthorAdapter
    {
        public List<AuthorDto> Adapt(IEnumerable<Author> authors)
        {
            List<AuthorDto> authorDtos = new();

            foreach (Author author in authors)
            {
                authorDtos.Add(new AuthorDto
                {
                    Id = author.Id,
                    Name = author.Name,
                    BirthDate = $"{author.BirthDate:dd/MM/yyyy}",
                    Nationality = author.Nationality,
                    Biography = author.Biography,
                });
            }

            return authorDtos;
        }

        public AuthorDto Adapt(Author author)
        {
            return new AuthorDto
            {
                Name = author.Name,
                BirthDate = author.BirthDate.ToString("dd/MM/yyyy"),
                Nationality = author.Nationality
            };
        }

        public Author ToEntity(AddAuthorDto author)
        {
            return new Author
            {
                Name = author.Name,
                BirthDate = author.BirthDate,
                Nationality = author.Nationality,
                Biography = author.Biography
            };
        }

        public Author ToEntity(UpdateAuthorCommand data)
        {
            return new Author
            {
                Id = data.AuthorId,
                Name = data.Author.Name,
                BirthDate = Convert.ToDateTime(data.Author.BirthDate),
                Nationality = data.Author.Nationality,
                Biography = data.Author.Biography
            };
        }
    }
}
