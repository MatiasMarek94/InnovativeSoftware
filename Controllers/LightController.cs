using System.Threading.Tasks;
using InnovativeSoftware.Helpers;
using InnovativeSoftware.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnovativeSoftware.Controllers
{
    public class LightController : BaseApiController
    { 
        private readonly ILightService _lightService;
        private readonly ParameterDescriptionAttribute _parameterDescription;

        public LightController(ILightService lightService, ParameterDescriptionAttribute parameterDescription)
        {
            _lightService = lightService;
            _parameterDescription = parameterDescription;
        }

        // GET
        [HttpGet("{id:int}")]
        public async Task<bool> TurnOffLight(int id)
        {
            return await _lightService.TurnOffLights(id);
        }
        
    }
}