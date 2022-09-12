using Core.Security.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.UserForRegister;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterCommand userForRegisterCommand)
        {
            UserForRegisterDto userForRegisterDto = await Mediator.Send(userForRegisterCommand);
            return Created("", userForRegisterDto);
        }

    }
}
