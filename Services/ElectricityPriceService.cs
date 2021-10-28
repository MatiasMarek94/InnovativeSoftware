using System;
using System.Linq;
using System.Threading.Tasks;
using InnovativeSoftware.Models;
using InnovativeSoftware.Repositories.Clients;
using InnovativeSoftware.Services.Interfaces;

namespace InnovativeSoftware.Services
{
    public class ElectricityPriceService : IElectricityPriceService
    {
        private readonly ElspotClient _elspotClient;

        public ElectricityPriceService(ElspotClient elspotClient)
        {
            _elspotClient = elspotClient;
        }

        public async Task<ElectricityPrice> GetCurrentPrice()
        {
            var result = await _elspotClient.GetPrice(DateTime.Now);
            var elspot = result.Result.Records.First();
            return new ElectricityPrice { DateTime = elspot.HourDK, Dkk = elspot.SpotPriceDKK };
        }
    }
}