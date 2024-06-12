using InkwellReads.Books.Application.Command.Authors;
using InkwellReads.Books.Application.Dto;
using InkwellReads.Books.Application.Query.Authors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace InkWellReads.Books.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IMediator Mediator { get; init; }
        public AuthorsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<AuthorDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<AuthorDto>> GetAuthors(CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetAuthorsQuery(), cancellationToken);

            return result;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(AuthorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AuthorResponse>> CreateAuthor([FromBody] AuthorCommand request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);

            return response;
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AuthorDto>> GetAuthor(string id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAuthorByIdQuery { AuthorId = id }, cancellationToken);

            return response;
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(AuthorResponse), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            await Mediator.Send(request, cancellationToken);

            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAuthor(string id, CancellationToken cancellationToken)
        {
            var request = new DeleteAuthorCommand { AuthorId = id };

            await Mediator.Send(request, cancellationToken);

            return NoContent();
        }
    }
}
