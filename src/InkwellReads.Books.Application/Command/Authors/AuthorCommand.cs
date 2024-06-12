using InkwellReads.Books.Application.Dto;
using MediatR;

namespace InkwellReads.Books.Application.Command.Authors
{
    public class AuthorCommand : IRequest<AuthorResponse>
    {
        public AddAuthorDto Author { get; set; }
    }
}
