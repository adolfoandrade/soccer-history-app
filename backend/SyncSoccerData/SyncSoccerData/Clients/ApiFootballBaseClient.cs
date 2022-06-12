using Newtonsoft.Json;
using SyncSoccerData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoccerData.Clients
{
    public class ApiFootballBaseClient : IApiFootballBaseClient
    {
        public async Task<T> GetAsync<T>(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "api-football-v1.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "ea52f2423emsh6d54b6bd79841a1p1f7a4ejsn1922d7f49e50");

            var result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<CountriesResponseVM> GetCountriesAsync()
        {
            string COUNTRIES_URL = "https://api-football-v1.p.rapidapi.com/v3/countries";
            var countries = await GetAsync<CountriesResponseVM>(COUNTRIES_URL);
            return countries;
        }

        public async Task<ResponseVM<FixtureEventsResponseVM>> GetFixtureEventsAsync(long fixture)
        {
            string FIXTURE_EVENTS_URL = $"https://api-football-v1.p.rapidapi.com/v3/fixtures/events?fixture={fixture}";
            var fixtureEvents = await GetAsync<ResponseVM<FixtureEventsResponseVM>>(FIXTURE_EVENTS_URL);
            return fixtureEvents;
        }

        public async Task<ResponseVM<FixtureLeagueResponseVM>> GetFixturesAsync(int league, int season)
        {
            string FIXTURES_URL = $"https://api-football-v1.p.rapidapi.com/v3/fixtures?league={league}&season={season}";
            var fixtures = await GetAsync<ResponseVM<FixtureLeagueResponseVM>>(FIXTURES_URL);
            return fixtures;
        }

        public async Task<ResponseVM<LeaguesResponseVM>> GetLeaguesAsync(string country)
        {
            string LEAGUES_URL = $"https://api-football-v1.p.rapidapi.com/v3/leagues?country={country}";
            var leagues = await GetAsync<ResponseVM<LeaguesResponseVM>>(LEAGUES_URL);
            return leagues;
        }

        public async Task<ResponseVM<TeamVenueResponseVM>> GetTeamsAsync(int league, int season)
        {
            string TEAMS_URL = $"https://api-football-v1.p.rapidapi.com/v3/teams?league={league}&season={season}";
            var teams = await GetAsync<ResponseVM<TeamVenueResponseVM>>(TEAMS_URL);
            return teams;
        }
    }
}
