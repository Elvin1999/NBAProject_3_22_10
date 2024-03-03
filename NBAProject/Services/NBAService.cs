using NBAProject.ApiEntities;
using NBAProject.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NBAProject.Services
{
    public class NBAService
    {
        public async Task<List<Response>> GetTeamsAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api-nba-v1.p.rapidapi.com/teams"),
                Headers =
    {
        { "X-RapidAPI-Key", ApiKeys.Key },
        { "X-RapidAPI-Host", "api-nba-v1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var data=JsonConvert.DeserializeObject<Rootobject>(body);
                var teams=data.response.ToList();
                return teams;
            }
        }
    }
}
