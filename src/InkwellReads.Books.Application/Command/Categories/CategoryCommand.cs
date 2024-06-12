using InkwellReads.Books.Application.Dto;
using MediatR;

namespace InkwellReads.Books.Application.Command.Categories
{
    public class CategoryCommand : IRequest<CategoryResponse>
    {
        public AddCategoryDto Category { get; set; }
    }
}
