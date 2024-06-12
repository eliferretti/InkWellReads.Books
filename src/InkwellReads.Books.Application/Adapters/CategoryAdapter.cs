using InkwellReads.Books.Application.Command.Categories;
using InkwellReads.Books.Application.Dto;
using InkWellReads.Books.Domain.Entities;

namespace InkwellReads.Books.Application.Adapters
{
    public class CategoryAdapter
    {
        public List<CategoryDto> Adapt(IEnumerable<Category> categories)
        {
            List<CategoryDto> categoryDtos = new();

            foreach (var category in categories)
            {
                categoryDtos.Add(new CategoryDto
                {
                    Name = category.Name,
                    Description = category.Description
                });
            }
            return categoryDtos;
        }

        public CategoryDto Adapt(Category category) 
        {
            return new CategoryDto
            {
                Name = category.Name,
                Description = category.Description
            };
        }

        public Category ToEntity(AddCategoryDto category) 
        {
            return new Category 
            { 
                Name = category.Name, 
                Description = category.Description 
            };
        }

        public Category ToEntity(UpdateCategoryCommand data)
        {
            return new Category 
            {
                Id = data.Category.Id,
                Name = data.Category.Name, 
                Description = data.Category.Description 
            };
        }
    }
}
