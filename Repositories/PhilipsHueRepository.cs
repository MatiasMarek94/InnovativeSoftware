using System.Collections.Generic;
using System.Threading.Tasks;
using InnovativeSoftware.Repositories.Clients;
using InnovativeSoftware.Repositories.Interfaces;
using InnovativeSoftware.Repositories.Models.PhilipsHue;

namespace InnovativeSoftware.Repositories
{
    public class PhilipsHueRepository : IPhilipsHueRepository
    {
        private readonly PhilipsHueClient _philipsHueClient;

        public PhilipsHueRepository(PhilipsHueClient philipsHueClient)
        {
            _philipsHueClient = philipsHueClient;
        }


        public async Task<bool> ChangeLightStatus(string userName, string token, int id, bool turnOn)
        {
            return await _philipsHueClient.ChangeLightStatus(userName, token, id, turnOn);
        }

        public async Task<Dictionary<string, PhilipsHueLightDTO>> GetAllLights(string userName, string token)
        {
            return await _philipsHueClient.GetAllLights(userName, token);
        }
    }
}