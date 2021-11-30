using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InnovativeSoftware.Repositories.Models.PhilipsHue;

namespace InnovativeSoftware.Services
{
    public interface ILightService
    {
        Task<object> SwitchState(string userName, string token, Guid guid, bool turnOn);
        Task<Dictionary<string, PhilipsHueLightDTO>> GetAllLights(string userName, string token);
    }
}