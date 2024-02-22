using Library.Application.Commands.Book.CreateBook;
using Library.Application.Commands.Book.DeleteBook;
using Library.Application.Queries.Book.GetAll;
using Library.Application.Queries.Book.GetBook;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/books")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Post")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
            var response = await _mediator.Send(command);
            
            if(!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201, response.Message);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var queryDelete = new DeleteBookCommand(id);

            var response = await _mediator.Send(queryDelete);

            if (!response.IsFound)
                return NotFound();

            return StatusCode(204);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllBooksQuery();

            var books = await _mediator.Send(query);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBookByIdQuery(id);

            var book = await _mediator.Send(query);

            if (book == null)
                return NotFound();

            return Ok(book);
        }
    }
}
