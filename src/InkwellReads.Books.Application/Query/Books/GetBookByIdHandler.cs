using AutoMapper;
using InkwellReads.Books.Application.Adapters;
using InkwellReads.Books.Application.Dto;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Query.Books
{
    public class GetBookByIdHandler: IRequestHandler<GetBookByIdQuery, BookDto>
    {
        public IRepository<Book, string> Repository { get; set; }
        private IMapper _mapper { get; init; }

        public GetBookByIdHandler(IRepository<Book, string> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await Repository.GetSingleAsync(request.BookId);

            var result = _mapper.Map<BookDto>(response);

            return await Task.FromResult(result);
        }
    }
}
