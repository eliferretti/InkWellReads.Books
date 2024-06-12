using InkwellReads.Books.Application.Dto;
using MediatR;

namespace InkwellReads.Books.Application.Command.Books
{
    public class BookCommand : IRequest<BookResponse>
    {
        public AddBookDto Book { get; set; }
    }
}
