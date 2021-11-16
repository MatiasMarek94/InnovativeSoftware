using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using InnovativeSoftware.Models;
using InnovativeSoftware.Repositories.Interfaces;
using InnovativeSoftware.Services.Interfaces;
using InnovativeSoftware.Services.Parameters;

namespace InnovativeSoftware.Services
{
    public class PowerUnitService : IPowerUnitService
    {
        private readonly IPowerUnitRepository _powerUnitRepository;

        public PowerUnitService(IPowerUnitRepository powerUnitRepository)
        {
            _powerUnitRepository = powerUnitRepository;
        }

        public async Task<Guid> Create(CreatePowerUnitParameters parameters)
        {
            var powerUnit = new PowerUnit
            {
                PowerUnitId = Guid.NewGuid(),
                DeviceId = parameters.DeviceId,
                Manufacturer = parameters.Manufacturer,
                Name = parameters.Name,
                On = parameters.On,
                Tags = parameters.Tags
            };

            var changeCount = await _powerUnitRepository.Create(powerUnit);
            if (changeCount != 1)
            {
                throw new IOException("Incorrect amount of changes were made!");
            }

            return powerUnit.PowerUnitId;
        }

        public async Task<PowerUnit> Get(GetPowerUnitParameters parameters)
        {
            return await _powerUnitRepository.Get(parameters.PowerUnitId);
        }

        public async Task<ICollection<PowerUnit>> List()
        {
            return await _powerUnitRepository.List();
        }

        public async Task<Guid> Update(Guid powerUnitId, UpdatePowerUnitParameters parameters)
        {
            var powerUnit = await _powerUnitRepository.Get(powerUnitId);
            powerUnit.DeviceId = parameters.DeviceId;
            powerUnit.Manufacturer = parameters.Manufacturer;
            powerUnit.Name = parameters.Name;
            powerUnit.On = parameters.On;
            powerUnit.Tags = parameters.Tags;

            var changeCount = await _powerUnitRepository.Update(powerUnit);
            if (changeCount > 1)
            {
                throw new IOException("Incorrect amount of changes were made!");
            }

            return powerUnit.PowerUnitId;
        }
    }
}