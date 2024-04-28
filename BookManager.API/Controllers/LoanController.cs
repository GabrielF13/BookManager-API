using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateLoanModel model)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateLoanModel model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}