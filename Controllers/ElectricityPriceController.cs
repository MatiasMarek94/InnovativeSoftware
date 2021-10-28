using System.Threading.Tasks;
using InnovativeSoftware.Models;
using InnovativeSoftware.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InnovativeSoftware.Controllers
{
    public class ElectricityPriceController : BaseApiController
    {
        private readonly IElectricityPriceService _electricityPriceService;

        public ElectricityPriceController(IElectricityPriceService electricityPriceService)
        {
            _electricityPriceService = electricityPriceService;
        }

        [HttpGet]
        public async Task<ElectricityPrice> Get()
        {
            return await _electricityPriceService.GetCurrentPrice();
        }
    }
}