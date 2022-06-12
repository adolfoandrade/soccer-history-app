using App.Domain.Interfaces;
using App.EventBus.IntegrationEvents.EventHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.Services
{
    public class StatistcsToBotIntegrationEventService : IStatistcsToBotIntegrationEventService
    {
        private readonly IEventBus _eventBus;
        private readonly ICompetitionRepository _competitonRepository;
        private readonly IStatisticRepository _statisticRepository;
        private readonly IMatchEventsRepository _matchEventsRepository;

        public StatistcsToBotIntegrationEventService(IEventBus eventBus,
            ICompetitionRepository competitonRepository,
            IStatisticRepository statisticRepository, 
            IMatchEventsRepository matchEventsRepository)
        {
            _eventBus = eventBus;
            _competitonRepository = competitonRepository;
            _statisticRepository = statisticRepository;
            _matchEventsRepository = matchEventsRepository;
        }

        public async Task Send(int id)
        {
            var statistic = new CompetitionStatisticIntegrationEvent();
            var competition = await _competitonRepository.GetBySeasonAsync(id, "2022");
            var matchEvents = await _matchEventsRepository.GetByCompetitionAsync(id);
            var goals = matchEvents.Where(x => x.Type.ToUpper() == "GOAL").GroupBy(x => x.EventId);
            var statistics = await _statisticRepository.GetByCompetitionAsync(id);
            var cornerKicks = statistics.Where(x => x.CornerKicks != null);

            statistic.Competition = competition;
            statistic.CornerKicks = new StatisticAvg() { Max = cornerKicks.Max(x => x.CornerKicks.Value), Avg = cornerKicks.Average(x => x.CornerKicks.Value), Min = cornerKicks.Min(x => x.CornerKicks.Value) };
            statistic.Goals = new StatisticAvg() { Max = goals.Max(x => x.Key), Avg = goals.Average(x => x.Key), Min = goals.Min(x => x.Key) };

            _eventBus.Publish(statistic);
        }
    }
}
