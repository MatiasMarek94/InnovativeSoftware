using System.Net.Http;
using System.Threading.Tasks;

namespace InnovativeSoftware.Repositories.Interfaces
{
    public interface IPhilipsHueRepository
    {
        public Task<HttpResponseMessage> AlterState(string userName, string token, int id, bool turnOn);
    }
}