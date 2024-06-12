using InkwellReads.Books.Application.Dto;
using MediatR;

namespace InkwellReads.Books.Application.Query.Authors
{
    public class GetAuthorsQuery : IRequest<IEnumerable<AuthorDto>>
    {
    }
}
