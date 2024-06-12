using InkwellReads.Books.Application.Dto;
using MediatR;

namespace InkwellReads.Books.Application.Query.Books
{
    public class GetBooksQuery : IRequest<IEnumerable<BookDto>>
    {
    }
}
