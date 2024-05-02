using BookManager.Application.Commands.CreateBook;
using BookManager.Application.Commands.DeleteBook;
using BookManager.Application.Commands.UpdateBook;
using BookManager.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMediator _mediator;

        public BookController(IBookService bookService, IMediator mediator)
        {
            _bookService = bookService;
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var books = _bookService.GetAll();

            return Ok(books);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}