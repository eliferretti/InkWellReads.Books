using InkwellReads.Books.Application.Dto;
using MediatR;

namespace InkwellReads.Books.Application.Query.Authors
{
    public class GetAuthorByIdQuery : IRequest<AuthorDto>
    {
        public string AuthorId { get; set; }
    }
}
