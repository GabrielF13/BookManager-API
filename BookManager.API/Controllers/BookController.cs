using BookManager.Application.InputModels;
using BookManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
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
        public async Task<IActionResult> Create([FromBody] CreateBookInputModel model)
        {
            var id = _bookService.Create(model);

            return CreatedAtAction(nameof(GetById), new { id }, model);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookInputModel model)
        {
            _bookService.Update(id, model);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _bookService.Delete(id);

            return Ok();
        }
    }
}