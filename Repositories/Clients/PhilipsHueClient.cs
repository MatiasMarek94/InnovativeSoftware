using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using InnovativeSoftware.Repositories.Models.PhilipsHue;
using Newtonsoft.Json;
using RestSharp;

namespace InnovativeSoftware.Repositories.Clients
{
    public class PhilipsHueClient
    {
        private readonly HttpClient _client;
        private string baseURL = "https://api.meethue.com/route/api/";

        public PhilipsHueClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> ChangeLightStatus(string userName, string token, int id, bool turnOn)
        {
            var client = new RestClient($"{baseURL}{userName}/lights/{id}/state");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            var body = "{\"on\":" + turnOn.ToString().ToLower() + "}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            return response.IsSuccessful;
        }

        public async Task<Dictionary<string, PhilipsHueLightDTO>> GetAllLights(string userName, string token)
        {
            var client = new RestClient($"https://api.meethue.com/bridge/{userName}/lights/");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {token}");
            IRestResponse response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<Dictionary<string, PhilipsHueLightDTO>>(response.Content);
            return result;
        }
    }
}