using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Command.Books
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, BookResponse>
    {
        private IRepository<Book, string> Repository { get; }

        public DeleteBookHandler(IRepository<Book, string> repository)
        {
            Repository = repository;
        }

        public async Task<BookResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await Repository.DeleteAsync(request.BookId);

            return await Task.FromResult(new BookResponse());
        }
    }
}
