using Library.Application.Commands.User.CreateUser;
using Library.Application.Commands.User.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Examples;

namespace Library.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    { 
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


         
        [HttpPost("Post")]
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);

            return StatusCode(201);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            try 
            {
                var loginUserviewModel = await _mediator.Send(command);

                if (!loginUserviewModel.IsFound)
                    return BadRequest("Email ou senha incorretos!");

                return Ok(loginUserviewModel);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            
        }


    }
}
