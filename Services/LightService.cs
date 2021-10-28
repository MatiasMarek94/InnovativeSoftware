using System.Threading.Tasks;
using InnovativeSoftware.Services.Factories;

namespace InnovativeSoftware.Services
{
    public class LightService : ILightService
    {
        private readonly IPhilipshueFactory _philipshueFactory;
        
        public Task<bool> TurnOffLights(int id)
        {
            //What type of light 
            //
            throw new System.NotImplementedException();
        }
    }
}