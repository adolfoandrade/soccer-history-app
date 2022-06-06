using SyncSoccerData.ViewModels;
using System.Threading.Tasks;

namespace SyncSoccerData.Services
{
    public interface ITeamsService
    {
        Task<ResponseVM<TeamVenueResponseVM>> GetAsync(int league, int season);
    }
}
