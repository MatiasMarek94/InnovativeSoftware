using System;
using System.Linq;
using System.Threading.Tasks;
using InnovativeSoftware.Models;
using InnovativeSoftware.Repositories.Clients;
using InnovativeSoftware.Repositories.Interfaces;

namespace InnovativeSoftware.Repositories
{
    public class Co2EmissionRepository : ICo2EmissionRepository
    {
        private readonly Co2EmissionPrognosisClient _co2EmissionPrognosisClient;

        public Co2EmissionRepository(Co2EmissionPrognosisClient co2EmissionPrognosisClient)
        {
            _co2EmissionPrognosisClient = co2EmissionPrognosisClient;
        }

        public async Task<Co2Emission> GetCurrentCo2Emission()
        {
            var result = await _co2EmissionPrognosisClient.GetCo2Emission(DateTime.Now);
            var co2Emission = result.Result.Records.First();
            const string unit = "g / kWh";
            return new Co2Emission
                { Co2Emitted = co2Emission.CO2Emission, DateTime = co2Emission.Minutes5DK, Unit = unit };
        }
    }
}