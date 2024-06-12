using MediatR;

namespace InkwellReads.Books.Application.Command.Categories
{
    public class DeleteCategoryCommand : IRequest<CategoryResponse>
    {
        public string CategoryId { get; set; }
    }
}
