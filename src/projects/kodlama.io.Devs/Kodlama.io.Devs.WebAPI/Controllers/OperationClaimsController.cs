using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            var result = await Mediator.Send(createOperationClaimCommand);
            return Created("", result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            var result = await Mediator.Send(updateOperationClaimCommand);
            return Ok(result);
        }
    }
}
