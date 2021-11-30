using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InnovativeSoftware.Repositories.Models.PhilipsHue;
using InnovativeSoftware.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnovativeSoftware.Controllers
{
    public class LightController : BaseApiController
    {
        private readonly ILightService _lightService;

        public LightController(ILightService lightService)
        {
            _lightService = lightService;
        }

        [HttpPut]
        public async Task<OkObjectResult> ChangeState(string userName, string token, Guid guid, bool turnOn)
        {
            var updated = await _lightService.SwitchState(userName, token, guid, turnOn);
            return Ok(updated);
        }

        [HttpGet("GetAllLights")]
        public async Task<Dictionary<string, PhilipsHueLightDTO>> GetAllLights(string userName, string token)
        {
            var result = await _lightService.GetAllLights(userName, token);
            return result;
        }
    }
}