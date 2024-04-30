using BookManager.API.Model;
using BookManager.Application.InputModels;
using BookManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserInputModel inputModel)
        {
            var id = _userService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}/login")]
        public async Task<IActionResult> Login(int id, [FromBody] LoginModel model)
        {
            return Ok();
        }
    }
}