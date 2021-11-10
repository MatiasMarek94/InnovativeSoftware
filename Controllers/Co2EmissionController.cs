using System.Threading.Tasks;
using InnovativeSoftware.Models;
using InnovativeSoftware.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InnovativeSoftware.Controllers
{
    public class Co2EmissionController : BaseApiController
    {
        private readonly ICo2EmissionService _co2EmissionService;

        public Co2EmissionController(ICo2EmissionService co2EmissionService)
        {
            _co2EmissionService = co2EmissionService;
        }

        [HttpGet]
        public async Task<Co2Emission> Get()
        {
            return await _co2EmissionService.GetCurrentCo2Emission();
        }
    }
}