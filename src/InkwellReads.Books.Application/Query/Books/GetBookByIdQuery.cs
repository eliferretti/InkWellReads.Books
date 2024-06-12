using InkwellReads.Books.Application.Dto;
using MediatR;

namespace InkwellReads.Books.Application.Query.Books
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public string BookId { get; set; }
    }
}
