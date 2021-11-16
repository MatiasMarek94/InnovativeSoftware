using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InnovativeSoftware.Infrastructure;
using InnovativeSoftware.Models;
using InnovativeSoftware.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InnovativeSoftware.Repositories
{
    public class PowerUnitRepository : IPowerUnitRepository
    {
        private readonly PowerUnitContext _context;

        public PowerUnitRepository(PowerUnitContext context)
        {
            _context = context;
        }

        public async Task<int> Create(PowerUnit powerUnit)
        {
            _context.PowerUnits.Add(powerUnit);
            var changes = await _context.SaveChangesAsync();
            return changes;
        }

        public async Task<PowerUnit> Get(Guid id)
        {
            var powerUnit = await _context.PowerUnits.FirstOrDefaultAsync(unit => unit.PowerUnitId.Equals(id));
            return powerUnit;
        }

        public async Task<ICollection<PowerUnit>> List()
        {
            return await _context.PowerUnits.ToListAsync();
        }

        public async Task<int> Update(PowerUnit powerUnit)
        {
            _context.PowerUnits.Update(powerUnit);
            var changes = await _context.SaveChangesAsync();
            return changes;
        }
    }
}