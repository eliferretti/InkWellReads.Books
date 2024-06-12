using AutoMapper;
using InkwellReads.Books.Application.Dto;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Query.Authors
{
    public class GetAuthorbyIdHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
    {
        private IRepository<Author, string> Repository { get; }
        private IMapper _mapper { get; init; }

        public GetAuthorbyIdHandler(IRepository<Author, string> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await Repository.GetSingleAsync(request.AuthorId);

            var result = _mapper.Map<AuthorDto>(response); 

            return await Task.FromResult(result);
        }
    }
}
