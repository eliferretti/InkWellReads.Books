using InkwellReads.Books.Application.Dto;
using MediatR;

namespace InkwellReads.Books.Application.Query.Categories
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
