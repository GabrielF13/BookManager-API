using BookManager.Application.Commands.CreateLoanBook;
using BookManager.Application.Commands.DeleteLoan;
using BookManager.Application.InputModels;
using BookManager.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        private readonly IMediator _mediator;

        public LoanController(ILoanService loanService, IMediator mediator)
        {
            _loanService = loanService;
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var loans = _loanService.GetAll();

            return Ok(loans);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var loan = _loanService.GetById(id);

            return Ok(loan);
        }

        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var loan = _loanService.GetByUserId(userId);

            return Ok(loan);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateLoanBookCommand command)
        {
            var id = _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLoanInputModel model)
        {
            _loanService.UpdateLoan(id, model);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteLoanCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}