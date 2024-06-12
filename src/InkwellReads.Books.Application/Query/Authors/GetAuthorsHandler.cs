using AutoMapper;
using InkwellReads.Books.Application.Dto;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Query.Authors
{
    public class GetAuthorsHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorDto>>
    {
        public IRepository<Author, string> Repository { get; init; }
        private IMapper _mapper { get; init; }

        public GetAuthorsHandler(IRepository<Author, string> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await Repository.GetAllAsync();

            var result = _mapper.Map<List<AuthorDto>>(authors);

            return await Task.FromResult(result);
        }
    }
}
