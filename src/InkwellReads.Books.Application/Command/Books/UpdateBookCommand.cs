using InkwellReads.Books.Application.Dto;
using MediatR;

namespace InkwellReads.Books.Application.Command.Books
{
    public class UpdateBookCommand : IRequest<BookResponse>
    {
        public string BookId { get; set; }
        public AddBookDto Book { get; set; }
    }
}
