using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.CreateFrameworkTechnology;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.DeleteFrameworkTechnology;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.UpdateFrameworkTechnology;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Models;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Queries.GetByIdFrameworkTechnology;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Queries.GetListByDynamicFrameworkTechnology;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Queries.GetListFrameworkTechnology;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworkTechnologiesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateFrameworkTechnologyCommand createFrameworkTechnologyCommand)
        {
            CreatedFrameworkTechnologyDto result = await Mediator.Send(createFrameworkTechnologyCommand);
            return Created("", result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateFrameworkTechnologyCommand updateFrameworkTechnologyCommand)
        {
            UpdatedFrameworkTechnologyDto result = await Mediator.Send(updateFrameworkTechnologyCommand);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteFrameworkTechnologyCommand deleteFrameworkTechnologyCommand)
        {
            DeletedFrameworkTechnologyDto result = await Mediator.Send(deleteFrameworkTechnologyCommand);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery]int id )
        {
            GetByIdFrameworkTechnologyQuery getByIdFrameworkTechnologyQuery = new() { Id = id };
            FrameworkTechnologyGetByIdDto frameworkTechnologyGetByIdDto = await Mediator.Send(getByIdFrameworkTechnologyQuery);
            return Ok(frameworkTechnologyGetByIdDto);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListFrameworkTechnologyQuery getListFrameworkTechnologyQuery = new() { PageRequest = pageRequest };
            FrameworkTechnologyListModel frameworkTechnologyListModel= await Mediator.Send(getListFrameworkTechnologyQuery);
            return Ok(frameworkTechnologyListModel);
        }

        [HttpPost("GetListByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListByDynamicFrameworkTechnologyQuery getListByDynamicFrameworkTechnologyQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };

            FrameworkTechnologyListModel frameworkTechnologyListModel = await Mediator.Send(getListByDynamicFrameworkTechnologyQuery);
            return Ok(frameworkTechnologyListModel);
        }

    }
}
