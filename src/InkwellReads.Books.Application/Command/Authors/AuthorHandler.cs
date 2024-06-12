using AutoMapper;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Command.Authors
{
    public class AuthorHandler : IRequestHandler<AuthorCommand, AuthorResponse>
    {
        private IRepository<Author, string> Repository { get; }
        private IMapper _mapper { get; init; }

        public AuthorHandler(IRepository<Author, string> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthorResponse> Handle(AuthorCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Author>(request.Author);

            await Repository.SaveAsync(result);

            var response = new AuthorResponse { AuthorId = result.Id };

            return await Task.FromResult(response);
        }
    }
}
