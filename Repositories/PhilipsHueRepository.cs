using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InnovativeSoftware.Models;
using InnovativeSoftware.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Expressions;
using static Microsoft.OpenApi.Expressions.BodyExpression;

namespace InnovativeSoftware.Repositories
{
    public class PhilipsHueRepository : IPhilipsHueRepository
    {
        
        private readonly HttpClient _client;
        private string baseURL = "https://api.meethue.com/bridge/";

        public PhilipsHueRepository(HttpClient client, string userName, string philipsHueToken)
        {
            _client = client;
            _client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + philipsHueToken);
            _client.BaseAddress =
                new Uri(baseURL ?? throw new InvalidOperationException());
        }

        public async Task<HttpResponseMessage> AlterState(string userName, string token, int id, bool turnOn)
        {
            var body = $"{{\"on\":{turnOn}}}";
            try
            {
                //should get userName from database
                var endpoint = userName + "/lights/" + id + "/state";
                return await _client.PutAsJsonAsync(endpoint, new StringContent(body));
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}