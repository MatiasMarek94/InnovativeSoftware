using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InnovativeSoftware.Models;
using InnovativeSoftware.Services.Parameters;

namespace InnovativeSoftware.Services.Interfaces
{
    public interface IPowerUnitService
    {
        public Task<Guid> Create(CreatePowerUnitParameters parameters);
        public Task<PowerUnit> Get(GetPowerUnitParameters parameters);
        public Task<ICollection<PowerUnit>> List();
        public Task<Guid> Update(Guid powerUnitId, UpdatePowerUnitParameters parameters);
    }
}