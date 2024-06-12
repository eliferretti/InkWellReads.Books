using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Command.Authors
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, string>
    {
        private IRepository<Author, string> Repository { get; }

        public DeleteAuthorHandler(IRepository<Author, string> repository)
        {
            Repository = repository;
        }

        public async Task<string> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            await Repository.DeleteAsync(request.AuthorId);

            return string.Empty;
        }
    }
}
