using AutoMapper;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Command.Categories
{
    public class CategoryHandler : IRequestHandler<CategoryCommand, CategoryResponse>
    {
        private IRepository<Category, string> Repository { get; }
        private IMapper _mapper { get; init; }

        public CategoryHandler(IRepository<Category, string> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> Handle(CategoryCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Category>(request.Category); 
            await Repository.SaveAsync(result);
            var response = new CategoryResponse { CategoryId = result.Id };

            return await Task.FromResult(response);
        }
    }
}
