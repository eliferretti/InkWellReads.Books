using AutoMapper;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Command.Authors
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, AuthorResponse>
    {
        private IRepository<Author, string> Repository { get; }
        private IMapper _mapper { get; init; }

        public UpdateAuthorHandler(IRepository<Author, string> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthorResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Author>(request.Author);

            await Repository.UpdateAsync(result);

            return await Task.FromResult(new AuthorResponse());
        }
    }
}
