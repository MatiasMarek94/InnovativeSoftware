using System.Threading.Tasks;
using InnovativeSoftware.Models;

namespace InnovativeSoftware.Services.Interfaces
{
    public interface ICo2EmissionService
    {
        public Task<Co2Emission> GetCurrentCo2Emission();
    }
}