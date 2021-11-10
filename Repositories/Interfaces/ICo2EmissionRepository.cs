using System.Threading.Tasks;
using InnovativeSoftware.Models;

namespace InnovativeSoftware.Repositories.Interfaces
{
    public interface ICo2EmissionRepository
    {
        public Task<Co2Emission> GetCurrentCo2Emission();
    }
}