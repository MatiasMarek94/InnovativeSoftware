using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InnovativeSoftware.Models;
using InnovativeSoftware.Repositories.Interfaces;
using InnovativeSoftware.Repositories.Models.PhilipsHue;
using InnovativeSoftware.Services.Interfaces;
using InnovativeSoftware.Services.Parameters;

namespace InnovativeSoftware.Services
{
    public class LightService : ILightService
    {
        private readonly IPhilipsHueRepository _philipshueRepository;
        private readonly IPowerUnitService _powerUnitService;

        public LightService(IPhilipsHueRepository philipshueRepository, IPowerUnitService powerUnitService)
        {
            _philipshueRepository = philipshueRepository;
            _powerUnitService = powerUnitService;
        }

        public async Task<object> SwitchState(string userName, string token, Guid powerUnitId, bool turnOn)
        {
            var powerUnit = await _powerUnitService.Get(new GetPowerUnitParameters { PowerUnitId = powerUnitId });
            var powerUnitManufacturer = powerUnit.Manufacturer;

            switch (powerUnitManufacturer)
            {
                case PowerUnitManufacturer.PhilipsHue:
                    var result =
                        await _philipshueRepository.ChangeLightStatus(userName, token, powerUnit.DeviceId, turnOn);
                    if (result)
                    {
                        await updatePowerUnitOn(powerUnit, turnOn);
                        Console.WriteLine("SwitchState update in switch if");
                        return true;
                    }

                    break;
                case PowerUnitManufacturer.Ikea:
                    return false;
                default:
                    return false;
            }

            return false;
        }

        public async Task<Dictionary<string, PhilipsHueLightDTO>> GetAllLights(string userName, string token)
        {
            var result = await _philipshueRepository.GetAllLights(userName, token);
            return result;
        }

        private async Task updatePowerUnitOn(PowerUnit powerUnit, bool isOn)
        {
            var updated = new UpdatePowerUnitParameters
            {
                Manufacturer = powerUnit.Manufacturer,
                Name = powerUnit.Name,
                On = isOn,
                Tags = powerUnit.Tags,
                DeviceId = powerUnit.DeviceId
            };
            await _powerUnitService.Update(powerUnit.PowerUnitId, updated);
        }
    }
}