using InkwellReads.Books.Application.Command.Books;
using InkwellReads.Books.Application.Dto;
using InkWellReads.Books.Domain.Entities;

namespace InkwellReads.Books.Application.Adapters
{
    public class BookAdapter
    {
        public List<BookDto> Adapt(IEnumerable<Book> books)
        {
            List<BookDto> bookDtos = new();

            foreach (Book book in books)
            {
                bookDtos.Add(new BookDto
                {
                    Title = book.Title,
                    Author = new AuthorDto
                    {
                        Id = book.Author.Id,
                        Name = book.Author.Name,
                        BirthDate = $"{book.Author.BirthDate:dd/MM/yyyy}", 
                        Nationality = book.Author.Nationality,
                        Biography = book.Author.Biography
                    },
                    Category = new CategoryDto 
                    {
                        Name = book.Category.Name,
                        Description = book.Category.Description
                    },
                    Synopsis = book.Synopsis,
                    Isbn = book.Isbn
                });
            }
            return bookDtos;
        }

        public BookDto Adapt(Book book)
        {
            return new BookDto
            {
                Title = book.Title,
                Author = new AuthorDto
                {
                    Id = book.Author.Id,
                    Name = book.Author.Name,
                    BirthDate = $"{book.Author.BirthDate:dd/MM/yyyy}",
                    Nationality = book.Author.Nationality,
                    Biography = book.Author.Biography
                },
                Category = new CategoryDto
                {
                    Name = book.Category.Name,
                    Description = book.Category.Description
                },
                Synopsis = book.Synopsis,
                Isbn = book.Isbn
            };
        }

        public Book ToEntity(AddBookDto book)
        {
            return new Book
            {
                Title = book.Title,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                PublicationDate = book.PublicationDate,
                Synopsis = book.Synopsis,
                Isbn = book.Isbn,
                Publisher = book.Publisher,
                Language = book.Language
            };
        }

        public Book ToEntity(UpdateBookCommand data)
        {
            return new Book
            {
                Id = data.BookId,
                Title = data.Book.Title,
                AuthorId = data.Book.AuthorId,
                PublicationDate = data.Book.PublicationDate,
                Synopsis = data.Book.Synopsis,
                Isbn = data.Book.Isbn,
                Publisher = data.Book.Publisher,
                Language = data.Book.Language
            };
        }
    }
}
