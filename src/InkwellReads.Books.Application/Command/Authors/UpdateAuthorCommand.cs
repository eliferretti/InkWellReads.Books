using InkwellReads.Books.Application.Dto;
using MediatR;

namespace InkwellReads.Books.Application.Command.Authors
{
    public class UpdateAuthorCommand : IRequest<AuthorResponse>
    {
        public string AuthorId { get; set; }
        public AuthorDto Author { get; set; }
    }
}
