using AutoMapper;
using InkwellReads.Books.Application.Dto;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Query.Books
{
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDto>>
    {
        public IRepository<Book, string> Repository { get; set; }
        private IMapper _mapper { get; init; }

        public GetBooksHandler(IRepository<Book, string> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await Repository.GetAllAsync();

            var result = _mapper.Map<List<BookDto>>(books);

            return await Task.FromResult(result);
        }
    }
}
