using AutoMapper;
using InkwellReads.Books.Application.Dto;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Query.Categories
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        public IRepository<Category, string> Repository { get; init; }
        private IMapper _mapper { get; init; }
        public GetCategoriesHandler(IRepository<Category, string> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await Repository.GetAllAsync();
            var adapted = _mapper.Map<List<CategoryDto>>(categories);
            return await Task.FromResult(adapted);

        }
    }
}
