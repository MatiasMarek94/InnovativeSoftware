using System;
using System.Net;
using System.Threading.Tasks;
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
        
        [HttpPut("/{id:guid}/{state:bool}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<OkObjectResult> ChangeState(string userName, string token, Guid id, int lightID, bool on)
        {
            var updated = await _lightService.SwitchState(userName, token, id, lightID, on);
            return Ok(updated);
        }
        
        
    }
}