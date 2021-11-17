using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InnovativeSoftware.Models;

namespace InnovativeSoftware.Repositories.Interfaces
{
    public interface IPowerUnitRepository
    {
        public Task<int> Create(PowerUnit powerUnit);
        public Task<PowerUnit> Get(Guid id);
        public Task<ICollection<PowerUnit>> List();
        public Task<int> Update(PowerUnit powerUnit);
    }
}