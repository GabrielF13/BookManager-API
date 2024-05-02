using BookManager.API.Model;
using BookManager.Application.Commands.CreateUser;
using BookManager.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public UserController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
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
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var id = _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}/login")]
        public async Task<IActionResult> Login(int id, [FromBody] LoginModel model)
        {
            return Ok();
        }
    }
}