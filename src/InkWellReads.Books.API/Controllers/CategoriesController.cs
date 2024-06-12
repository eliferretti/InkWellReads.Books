using InkwellReads.Books.Application.Command.Categories;
using InkwellReads.Books.Application.Dto;
using InkwellReads.Books.Application.Query.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace InkWellReads.Books.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IMediator Mediator { get; init; }

        public CategoriesController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<CategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<CategoryDto>> GetCategories(CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetCategoriesQuery(), cancellationToken);

            return result;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryResponse>> CreateCategory([FromBody] CategoryCommand request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);

            return response;
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryDto>> GetCategory(string id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetCategoryByIdQuery { CategoryId = id }, cancellationToken);

            return response;
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await Mediator.Send(request, cancellationToken);

            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategory(string id, CancellationToken cancellationToken)
        {
            var request = new DeleteCategoryCommand { CategoryId = id };

            await Mediator.Send(request, cancellationToken);

            return StatusCode(StatusCodes.Status204NoContent);
        }

    }
}
