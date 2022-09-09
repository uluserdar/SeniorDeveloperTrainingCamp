using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.CreateFrameworkTechnology;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.DeleteFrameworkTechnology;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.UpdateFrameworkTechnology;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworkTechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFrameworkTechnologyCommand createFrameworkTechnologyCommand)
        {
            CreatedFrameworkTechnologyDto result = await Mediator.Send(createFrameworkTechnologyCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFrameworkTechnologyCommand updateFrameworkTechnologyCommand)
        {
            UpdatedFrameworkTechnologyDto result = await Mediator.Send(updateFrameworkTechnologyCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteFrameworkTechnologyCommand deleteFrameworkTechnologyCommand)
        {
            DeletedFrameworkTechnologyDto result = await Mediator.Send(deleteFrameworkTechnologyCommand);
            return Ok(result);
        }
    }
}
