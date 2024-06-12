using AutoMapper;
using InkwellReads.Books.Application.Adapters;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Command.Books
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, BookResponse>
    {
        private IRepository<Book, string> Repository { get; }
        private IMapper _mapper { get; init; }

        public UpdateBookHandler(IRepository<Book, string> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }
        public async Task<BookResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Book>(request);

            await Repository.UpdateAsync(result);

            return await Task.FromResult(new BookResponse());
        }
    }
}
