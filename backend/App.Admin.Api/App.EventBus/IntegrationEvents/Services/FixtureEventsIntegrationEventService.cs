using App.Domain.Interfaces;
using App.Domain.Models;
using App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.Services
{
    public class FixtureEventsIntegrationEventService : IFixtureEventsIntegrationEventService
    {
        private readonly IApiValueReferenceRepository _referenceRepository;
        private readonly IMatchEventsRepository _matchEventRepository;

        public FixtureEventsIntegrationEventService(IApiValueReferenceRepository referenceRepository,
            IMatchEventsRepository matchEventRepository)
        {
            _referenceRepository = referenceRepository;
            _matchEventRepository = matchEventRepository;
        }

        public async Task<bool> AddOrUpdateAsync(List<FixtureEventsResponseVM> vm, long id)
        {
            foreach (var item in vm)
            {
                var fixture = await _referenceRepository.GetByApiIdAsync("EVENTS", (int)id);
                var team = await _referenceRepository.GetByApiIdAsync("TEAMS", item.Team.Id.Value);
                if(fixture != null && team != null)
                {
                    var fixture_event = new MatchEvent()
                    {
                        TeamId = team.AppId,
                        EventId = fixture.AppId,
                        Type = item.Type,
                        Detail = item.Detail,
                        Comments = item.Comments,
                        Assist = item.Assist?.Name,
                        Elapsed = item.Time.Elapsed.HasValue ? item.Time.Elapsed.Value : 0,
                        Extra = item.Time.Extra.HasValue ? item.Time.Extra.Value : 0
                    };
                    var has = await _matchEventRepository.HasAsync(fixture_event.TeamId, fixture_event.EventId, fixture_event.Type, fixture_event.Elapsed, fixture_event.Extra);
                    if (has == null)
                    {
                        await _matchEventRepository.AddAsync(fixture_event);
                    }
                }
            }
            return true;
        }
    }
}
