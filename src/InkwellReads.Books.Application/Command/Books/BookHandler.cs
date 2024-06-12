using AutoMapper;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Command.Books
{
    public class BookHandler : IRequestHandler<BookCommand, BookResponse>
    {
        private IRepository<Book, string> Repository { get; }
        private IMapper _mapper { get; init; }

        public BookHandler(IRepository<Book, string> repository, IMapper mapper) 
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async Task<BookResponse> Handle(BookCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Book>(request.Book);

            await Repository.SaveAsync(result);

            var response = new BookResponse { BookId = result.Id };

            return await Task.FromResult(response);
        }
    }
}
