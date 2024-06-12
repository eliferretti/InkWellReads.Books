using AutoMapper;
using InkwellReads.Books.Application.Dto;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using MediatR;

namespace InkwellReads.Books.Application.Query.Categories
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private IRepository<Category, string> Repository { get; }
        private IMapper _mapper { get; init; }
        public GetCategoryByIdHandler(IRepository<Category, string> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await Repository.GetSingleAsync(request.CategoryId);

            var adapter = _mapper.Map<CategoryDto>(response);

            return await Task.FromResult(adapter);
        }
    }
}
