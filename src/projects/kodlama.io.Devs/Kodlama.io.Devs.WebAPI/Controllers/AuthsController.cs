using Core.Security.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.UserForRegister;
using Kodlama.io.Devs.Application.Features.Authentications.Queries.UserForLogin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterCommand userForRegisterCommand)
        {
            UserForRegisterDto userForRegisterDto = await Mediator.Send(userForRegisterCommand);
            return Created("", userForRegisterDto);
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromQuery] UserForLoginQuery userForLoginQuery)
        {
            var result = await Mediator.Send(userForLoginQuery);
            return Ok(result);
        }

    }
}
