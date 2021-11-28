using System;
using System.Threading.Tasks;
using InnovativeSoftware.Models;

namespace InnovativeSoftware.Services
{
    public interface ILightService
    {
        Task<object> SwitchState(string userName, string token, Guid id, int lightID, bool turnOn);
    }
}