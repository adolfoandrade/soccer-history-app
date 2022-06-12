using App.Domain.Interfaces;
using App.Domain.Models;
using App.Models;
using App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.Services
{
    public class TeamsIntegrationEventService : ITeamsIntegrationEventService
    {
        private readonly IApiValueReferenceRepository _referenceRepository;
        private readonly ISoccerTeamRepository _teamsRepository;

        public TeamsIntegrationEventService(IApiValueReferenceRepository referenceRepository,
            ISoccerTeamRepository teamsRepository)
        {
            _referenceRepository = referenceRepository;
            _teamsRepository = teamsRepository;
        }

        public async Task<bool> AddAsync(List<TeamVenueResponseVM> vm)
        {
            foreach (var item in vm)
            {
                var has = await _referenceRepository.GetByApiIdAsync("TEAMS", item.Team.Id);
                if (has == null)
                {
                    var team = new SoccerTeam()
                    {
                        Country = item.Team.Country,
                        Name = item.Team.Name,
                        Image = item.Team.Logo,
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                    };
                    var teamId = await _teamsRepository.AddAsync(team);
                    var reference = new ApiValueReference()
                    {
                        TableReference = "TEAMS",
                        ApiName = "api-football",
                        ApiId = item.Team.Id,
                        AppId = teamId
                    };
                    await _referenceRepository.AddAsync(reference);
                }
            }
            return true;
        }
    }
}
