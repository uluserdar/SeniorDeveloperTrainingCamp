using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.DeleteUser;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.RegisterUser;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.UpdateUser;
using Kodlama.io.Devs.Application.Features.Authentications.Queries.GetByIdUser;
using Kodlama.io.Devs.Application.Features.Authentications.Queries.GetListByDynamicUser;
using Kodlama.io.Devs.Application.Features.Authentications.Queries.GetListUser;
using Kodlama.io.Devs.Application.Features.Authentications.Queries.LoginUser;
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
            var result = await Mediator.Send(registerUserCommand);
            return Created("", result);
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromQuery] LoginUserQuery loginUserQuery)
        {
            var result = await Mediator.Send(loginUserQuery);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            var result = await Mediator.Send(updateUserCommand);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody]DeleteUserCommand deleteUserCommand)
        {
            var result = await Mediator.Send(deleteUserCommand);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            GetByIdUserQuery getUserByIdQuery = new() { Id = id };
            var result = await Mediator.Send(getUserByIdQuery);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery getListUserQuery = new GetListUserQuery { PageRequest = pageRequest };
            var result = await Mediator.Send(getListUserQuery);
            return Ok(result);
        }

        [HttpPost("GetListByDynamic")]
        public async Task<IActionResult> GetLisByDynamic([FromQuery] PageRequest pageRequest, [FromBody]Dynamic dynamic)
        {
            GetListByDynamicUserQuery getListByDynamicUserQuery = new GetListByDynamicUserQuery { PageRequest=pageRequest,Dynamic=dynamic };
            var result =await Mediator.Send(getListByDynamicUserQuery);

            return Ok(result);
        }

    }
}
