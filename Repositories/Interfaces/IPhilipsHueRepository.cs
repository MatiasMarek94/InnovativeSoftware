using System.Collections.Generic;
using System.Threading.Tasks;
using InnovativeSoftware.Repositories.Models.PhilipsHue;

namespace InnovativeSoftware.Repositories.Interfaces
{
    public interface IPhilipsHueRepository
    {
        public Task<bool> ChangeLightStatus(string userName, string token, int id, bool turnOn);
        public Task<Dictionary<string, PhilipsHueLightDTO>> GetAllLights(string userName, string token);
    }
}