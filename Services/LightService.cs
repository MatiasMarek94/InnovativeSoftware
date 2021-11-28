using System;
using System.Threading.Tasks;
using InnovativeSoftware.Controllers;
using InnovativeSoftware.Models;
using InnovativeSoftware.Repositories.Interfaces;
using InnovativeSoftware.Services.Interfaces;
using InnovativeSoftware.Services.Parameters;

namespace InnovativeSoftware.Services
{
    public class LightService : ILightService
    {
        private readonly IPhilipsHueRepository _philipshueRepository;
        private readonly IPowerUnitService _powerUnitService ;

        public LightService(IPhilipsHueRepository philipshueRepository, IPowerUnitService powerUnitService)
        {
            _philipshueRepository = philipshueRepository;
            _powerUnitService = powerUnitService;
        }

        public async Task<object> SwitchState(string userName, string token, Guid powerUnitID, int lightNr, bool turnOn)
        {
            var powerUnit = await _powerUnitService.Get(new GetPowerUnitParameters { PowerUnitId = powerUnitID });
            var powerUnitManufacturer = powerUnit.Manufacturer;

            switch (powerUnitManufacturer)
            {
                case PowerUnitManufacturer.PhilipsHue : 
                    await _philipshueRepository.AlterState(userName, token, lightNr, turnOn);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return null;
        }
    }
}