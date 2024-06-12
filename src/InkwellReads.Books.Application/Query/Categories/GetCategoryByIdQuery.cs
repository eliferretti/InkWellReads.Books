using InkwellReads.Books.Application.Dto;
using MediatR;

namespace InkwellReads.Books.Application.Query.Categories
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public string CategoryId { get; set; }
    }
}
