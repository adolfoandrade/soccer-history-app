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
    public class FixtureIntegrationEventService : IFixtureIntegrationEventService
    {
        private readonly IApiValueReferenceRepository _referenceRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly ISoccerEventRepository _eventRepository;

        public FixtureIntegrationEventService(IApiValueReferenceRepository referenceRepository,
            IMatchRepository matchRepository,
            ISoccerEventRepository eventRepository)
        {
            _referenceRepository = referenceRepository;
            _matchRepository = matchRepository;
            _eventRepository = eventRepository;
        }

        public async Task<bool> AddOrUpdateAsync(List<FixtureLeagueResponseVM> vm)
        {
            var teams_references = await _referenceRepository.GetByTableNameAsync("TEAMS");
            var competitions_references = await _referenceRepository.GetByTableNameAsync("COMPETITIONS");
            foreach (var item in vm)
            {
                var home = teams_references.FirstOrDefault(x => x.ApiId == item.Teams.Home.Id);
                var away = teams_references.FirstOrDefault(x => x.ApiId == item.Teams.Away.Id);
                var round = 1;
                string stage = string.Empty;
                try
                {
                    var roundNumber = item.League.Round.Substring(item.League.Round.Length - 2, 2);
                    round = int.Parse(roundNumber);
                }
                catch (Exception)
                {
                    stage = item.League.Round;
                }
                
                var competition = competitions_references.FirstOrDefault(x => x.ApiId == item.League.Id && item.League.Season == 2022);

                if (home == null || away == null)
                {
                    continue;
                }
           
                var match = await _matchRepository.GetByMatchNumerAsync(int.Parse(round.ToString()), competition.AppId);
                if (match is null)
                {
                    match = new Match { CompetitionId = competition.AppId, Number = int.Parse(round.ToString()) };
                    if (!string.IsNullOrEmpty(stage))
                    {
                        match.Stage = stage;
                    }
                    await _matchRepository.AddAsync(match);
                    match = await _matchRepository.GetByMatchNumerAsync(match.Number, match.CompetitionId);
                }
                var theEvent = new SoccerEvent()
                {
                    MatchId = match.Id,
                    HomeTeamId = home.AppId,
                    OutTeamId = away.AppId,
                    Referee = item.Fixture.Referee,
                    Venue = item.Fixture.Venue?.Name,
                    Date = item.Fixture.Date,
                    Status = item.Fixture.Status.Long
                };
                var has = await _eventRepository.HasAsync(match.CompetitionId, match.Id, theEvent.HomeTeamId, theEvent.OutTeamId, theEvent.Date);
                if(has == null)
                {
                    var eventId = await _eventRepository.AddAsync(theEvent);
                    var reference = new ApiValueReference()
                    {
                        TableReference = "EVENTS",
                        ApiName = "api-football",
                        ApiId = (int)item.Fixture.Id,
                        AppId = eventId
                    };
                    await _referenceRepository.AddAsync(reference);
                } 
                else
                {
                    var has_reference = await _referenceRepository.GetByApiIdAsync("EVENTS", (int)item.Fixture.Id);
                    if(has_reference == null)
                    {
                        var reference = new ApiValueReference()
                        {
                            TableReference = "EVENTS",
                            ApiName = "api-football",
                            ApiId = (int)item.Fixture.Id,
                            AppId = has.Id
                        };
                        await _referenceRepository.AddAsync(reference);
                    }
                    if(has.Status == null || (has.Status.ToUpper() != item.Fixture.Status.Long.ToUpper()))
                    {
                        has.Status = item.Fixture.Status.Long;
                        has.Referee = item.Fixture.Referee;
                        has.Venue = item.Fixture.Venue?.Name;
                        has.Date = item.Fixture.Date;
                        await _eventRepository.UpdateAsync(has);
                    }
                }
            }
            return true;
        }
    }
}
