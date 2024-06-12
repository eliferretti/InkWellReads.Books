using AutoMapper;
using InkwellReads.Books.Application.Adapters;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Command.Categories
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponse>
    {
        private IRepository<Category, string> CategoryRepository { get; }
        private IMapper _mapper { get; init; }

        public UpdateCategoryHandler(IRepository<Category, string> repository, IMapper mapper)
        {
            CategoryRepository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Category>(request.Category);
            await CategoryRepository.UpdateAsync(result);

            return await Task.FromResult(new CategoryResponse());
        }
    }
}
