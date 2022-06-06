using SyncSoccerData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoccerData.Services
{
    public class TeamsService : ITeamsService
    {
        public Task<ResponseVM<TeamVenueResponseVM>> GetAsync(int league, int season)
        {
            throw new NotImplementedException();
        }
    }
}
