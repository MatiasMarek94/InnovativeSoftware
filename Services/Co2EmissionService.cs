using System.Threading.Tasks;
using InnovativeSoftware.Models;
using InnovativeSoftware.Repositories.Interfaces;
using InnovativeSoftware.Services.Interfaces;

namespace InnovativeSoftware.Services
{
    public class Co2EmissionService : ICo2EmissionService
    {
        private readonly ICo2EmissionRepository _co2EmissionRepository;

        public Co2EmissionService(ICo2EmissionRepository co2EmissionRepository)
        {
            _co2EmissionRepository = co2EmissionRepository;
        }

        public Task<Co2Emission> GetCurrentCo2Emission()
        {
            return _co2EmissionRepository.GetCurrentCo2Emission();
        }
    }
}