using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InnovativeSoftware.Repositories.Models;
using InnovativeSoftware.Repositories.Models.Ckan;

namespace InnovativeSoftware.Repositories.Clients
{
    public class Co2EmissionPrognosisClient
    {
        private readonly HttpClient _client;

        public Co2EmissionPrognosisClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.energidataservice.dk/datastore_search_sql");

            _client = client;
        }

        public async Task<Ckan<Co2Emission>> GetCo2Emission(DateTime datetime)
        {
            var currentTime = datetime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            var pastTime = datetime.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            Console.WriteLine(currentTime);
            var sql = "SELECT * FROM \"co2emisprog\" WHERE \"PriceArea\" = 'DK1' AND \"Minutes5DK\" < '" + currentTime +
                      "' AND \"Minutes5DK\" > '" + pastTime + "' ORDER BY \"Minutes5DK\" DESC LIMIT 1";
            return await _client.GetFromJsonAsync<Ckan<Co2Emission>>("?sql=" + sql);
        }
    }
}