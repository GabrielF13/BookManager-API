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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = _bookService.GetAll();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] NewBookInputModel model)
        {
            var id = _bookService.Create(model);

            return CreatedAtAction(nameof(GetById), new { id = id }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateBookInputModel model)
        {
            _bookService.Update(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _bookService.Delete(id);

            return Ok();
        }
    }
}