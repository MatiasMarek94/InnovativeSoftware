using System.Threading.Tasks;

namespace InnovativeSoftware.Services
{
    public interface ILightService
    {
        Task<bool> TurnOffLights(int id);
    }
}