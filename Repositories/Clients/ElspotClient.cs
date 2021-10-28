using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InnovativeSoftware.Repositories.Models;
using InnovativeSoftware.Repositories.Models.Ckan;

namespace InnovativeSoftware.Repositories.Clients
{
    public class ElspotClient
    {
        private readonly HttpClient _client;

        public ElspotClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.energidataservice.dk/datastore_search_sql");

            _client = client;
        }

        public async Task<Ckan<ElspotPrice>> GetPrice(DateTime datetime)
        {
            var currentTime = datetime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            var pastTime = datetime.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            Console.WriteLine(currentTime);
            var sql = "SELECT * FROM \"elspotprices\" WHERE \"PriceArea\" = 'DK1' AND \"HourDK\" < '" + currentTime +
                      "' AND \"HourDK\" > '" + pastTime + "' ORDER BY \"HourDK\" DESC LIMIT 1";
            return await _client.GetFromJsonAsync<Ckan<ElspotPrice>>(
                "?sql=" + sql);
        }
    }
}