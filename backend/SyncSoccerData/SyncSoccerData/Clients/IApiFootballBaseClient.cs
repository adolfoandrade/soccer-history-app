using SyncSoccerData.ViewModels;
using System.Threading.Tasks;

namespace SyncSoccerData.Clients
{
    public interface IApiFootballBaseClient
    {
        Task<CountriesResponseVM> GetCountriesAsync();
        Task<ResponseVM<LeaguesResponseVM>> GetLeaguesAsync(string country);
        Task<ResponseVM<TeamVenueResponseVM>> GetTeamsAsync(int league, int season);    
        Task<ResponseVM<FixtureLeagueResponseVM>> GetFixturesAsync(int league, int season);
        Task<ResponseVM<FixtureEventsResponseVM>> GetFixtureEventsAsync(long fixture);
        Task<ResponseVM<FixtureStatisticsResponseVM>> GetFixtureStatisticsAsync(long fixture);
        Task<T> GetAsync<T>(string url);
    }
}
