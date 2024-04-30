using BookManager.Application.InputModels;
using BookManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loans = _loanService.GetAll();

            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var loan = _loanService.GetById(id);

            return Ok(loan);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var loan = _loanService.GetByUserId(userId);

            return Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateLoanBookInputModel model)
        {
            var id = _loanService.CreateLoanBook(model);

            return CreatedAtAction(nameof(GetById), new { id }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateLoanInputModel model)
        {
            _loanService.UpdateLoan(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _loanService.DeleteLoan(id);

            return Ok();
        }
    }
}