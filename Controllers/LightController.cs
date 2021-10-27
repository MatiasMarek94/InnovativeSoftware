using System.Threading.Tasks;
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

        // GET
        [HttpGet("{id:int}")]
        public async Task<bool> TurnOffLight(int id)
        {
            return await _lightService.TurnOffLights(id);
        }
        
    }
}