using MediatR;

namespace InkwellReads.Books.Application.Command.Books
{
    public class DeleteBookCommand : IRequest<BookResponse>
    {
        public string BookId { get; set; }
    }
}
