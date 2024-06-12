using InkwellReads.Books.Application.Command.Books;
using InkwellReads.Books.Application.Dto;
using InkwellReads.Books.Application.Query.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace InkWellReads.Books.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<BookDto>> GetBooks(CancellationToken cancellationToken)
        {
            var request = new GetBooksQuery();

            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookResponse>> CreateBook([FromBody] BookCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return response;
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookDto>> GetBook(string id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetBookByIdQuery { BookId = id }, cancellationToken);

            return response;
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<BookResponse> UpdateBook([FromBody] UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return response;
        }

        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(BookResponse), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBook(string id, CancellationToken cancellationToken)
        {
            var request = new DeleteBookCommand { BookId = id };

            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
