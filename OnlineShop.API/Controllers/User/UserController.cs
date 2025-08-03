using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.User;
using OnlineShop.Application.Features.User.Requests.Command;
using OnlineShop.Application.Features.User.Requests.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UserController>
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            var request = new RegisterUserRequest() { CreateUserDto = createUserDto };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // GET api/<UserController>/5
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var request = new LoginUserRequest() { LoginUserDto = loginUserDto };
            var result = await _mediator.Send(request);
            return NotFound(result);
        }
    }
}
