using Core.Security.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.RegisterUser;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Queries.LoginUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            RegisteredUserDto registeredUserDto = await Mediator.Send(registerUserCommand);
            return Created("", registeredUserDto);
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromQuery] LoginUserQuery loginUserQuery)
        {
            var result = await Mediator.Send(loginUserQuery);
            return Ok(result);
        }

    }
}
