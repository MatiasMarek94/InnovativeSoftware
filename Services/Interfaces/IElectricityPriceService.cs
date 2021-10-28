using System.Threading.Tasks;
using InnovativeSoftware.Models;

namespace InnovativeSoftware.Services.Interfaces
{
    public interface IElectricityPriceService
    {
        public Task<ElectricityPrice> GetCurrentPrice();
    }
}