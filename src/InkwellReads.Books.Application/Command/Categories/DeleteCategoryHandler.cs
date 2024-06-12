using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Command.Categories
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, CategoryResponse>
    {
        private IRepository<Category, string> Repository { get; }

        public DeleteCategoryHandler(IRepository<Category, string> repository)
        {
            Repository = repository;
        }
        public async Task<CategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await Repository.DeleteAsync(request.CategoryId);

            return await Task.FromResult(new CategoryResponse());
        }
    }
}
