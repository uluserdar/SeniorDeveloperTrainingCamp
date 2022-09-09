﻿using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.CreateFrameworkTechnology;
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
    }
}
