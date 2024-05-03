using BookManager.Application.Commands.CreateLoanBook;
using BookManager.Application.Commands.DeleteLoan;
using BookManager.Application.Commands.UpdateLoan;
using BookManager.Application.Queries.GetAllLoans;
using BookManager.Application.Queries.GetLoanById;
using BookManager.Application.Queries.GetLoanByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllLoansQuery();

            var loans = _mediator.Send(query);

            return Ok(loans);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetLoanByIdQuery(id);

            var loan = await _mediator.Send(query);

            return Ok(loan);
        }

        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var query = new GetLoanByUserIdQuery(userId);

            var loan = _mediator.Send(query);

            return Ok(loan);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateLoanBookCommand command)
        {
            var id = _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLoanCommand command)
        {
            await _mediator.Send(command);

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