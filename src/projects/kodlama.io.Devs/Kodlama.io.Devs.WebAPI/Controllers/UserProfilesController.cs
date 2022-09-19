using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.UpdateUser;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.CreateUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.DeleteUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.UpdateUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Queries.GetByIdUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Queries.GetListByDynamicUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Queries.GetListUserProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserProfileCommand createUserProfileCommand)
        {
            var result =await Mediator.Send(createUserProfileCommand);
            return Created("", result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateUserProfileCommand updateUserProfileCommand)
        {
            var result = await Mediator.Send(updateUserProfileCommand);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody]DeleteUserProfileCommand deleteUserProfileCommand)
        {
            var result = await Mediator.Send(deleteUserProfileCommand);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            GetByIdUserProfileQuery getByIdUserProfileQuery = new() { Id = id };
            var result = await Mediator.Send(getByIdUserProfileQuery);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
        {
            GetListUserProfileQuery getListUserProfileQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListUserProfileQuery);
            return Ok(result);
        }

        [HttpPost("GetListByDynamic")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody]Dynamic dynamic)
        {
            GetListByDynamicUserProfileQuery getListByDynamicUserProfileQuery = new() { PageRequest = pageRequest,Dynamic=dynamic };
            var result = await Mediator.Send(getListByDynamicUserProfileQuery);
            return Ok(result);
        }

    }
}
