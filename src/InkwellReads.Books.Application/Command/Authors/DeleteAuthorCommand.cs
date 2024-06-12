using MediatR;

namespace InkwellReads.Books.Application.Command.Authors
{
    public class DeleteAuthorCommand : IRequest<string>
    {
        public string AuthorId { get; set; }
    }
}
