using InkwellReads.Books.Application.Dto;
using MediatR;

namespace InkwellReads.Books.Application.Command.Categories
{
    public class UpdateCategoryCommand: IRequest<CategoryResponse>
    {
        public CategoryDto Category { get; set; }
    }
}
