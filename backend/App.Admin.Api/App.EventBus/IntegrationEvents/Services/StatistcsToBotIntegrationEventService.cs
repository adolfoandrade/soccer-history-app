using App.Domain.Interfaces;
using App.Domain.Models;
using App.Domain.Models.Enum;
using App.EventBus.IntegrationEvents.EventHandling;
using App.Models;
using Newtonsoft.Json;
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
        private readonly ISoccerEventRepository _eventRepository;
        private readonly IApiValueReferenceRepository _referenceRepository;
        private readonly IStatisticRepository _statisticRepository;
        private readonly IMatchEventsRepository _matchEventsRepository;

        public StatistcsToBotIntegrationEventService(IEventBus eventBus,
            ICompetitionRepository competitonRepository,
            IApiValueReferenceRepository referenceRepository,
            IStatisticRepository statisticRepository,
            IMatchEventsRepository matchEventsRepository,
            ISoccerEventRepository eventRepository)
        {
            _eventBus = eventBus;
            _competitonRepository = competitonRepository;
            _referenceRepository = referenceRepository;
            _statisticRepository = statisticRepository;
            _matchEventsRepository = matchEventsRepository;
            _eventRepository = eventRepository;
        }

        public async Task Send(int id)
        {
            var statistic = new CompetitionStatisticIntegrationEvent();
            var reference = await _referenceRepository.GetByApiIdAsync("COMPETITIONS", id);
            var competition = await _competitonRepository.GetBySeasonAsync(reference.AppId, "2022");
            var matchEvents = await _matchEventsRepository.GetByCompetitionAsync(competition.Id);
            var events = await _eventRepository.GetByCompetitionAsync(competition.Id);
            var statistics = await _statisticRepository.GetByCompetitionAsync(competition.Id);
            var matches = await _statisticRepository.GetMatchesByCompetitionAsync(competition.Id);
            var cards = await _statisticRepository.GetCardsByMatchAsync(competition.Id);
            var goals = await _statisticRepository.GetGoalsByCompetitionsAsync(competition.Id);
            var statisticCompetition = new StatisticCompetition()
            {
                Competition = competition,
                StatisticsOddByMatch = new List<StatisticOddByMatch>(),
                NextEvents = events.Where(x => x.Status != "Match Finished")
            };
            var bothTeamsScore = await BothTeamsScore(matches);
            var goalsOverOrUnder = await GoalsOverOrUnder(matches);
            var goalsOverOrUnderFirstHalf = GoalsOverOrUnderFirstHalf(matches, goals);
            var goalsOverOrUnderSecondHalf = GoalsOverOrUnderSecondHalf(matches, goals);
            statisticCompetition.StatisticsOddByMatch.AddRange(bothTeamsScore);
            statisticCompetition.StatisticsOddByMatch.AddRange(goalsOverOrUnder);
            statisticCompetition.StatisticsOddByMatch.AddRange(goalsOverOrUnderFirstHalf);
            statisticCompetition.StatisticsOddByMatch.AddRange(goalsOverOrUnderSecondHalf);

            if (statistics.Any())
            {
                var cornersOverUnder = CornersOverUnder(matches, statistics.Where(x => x.CornerKicks != null));
                statisticCompetition.StatisticsOddByMatch.AddRange(cornersOverUnder);
            }
            
            statistic.Statistics = JsonConvert.SerializeObject(statisticCompetition);
            await _statisticRepository.SaveDataOddAsync(statisticCompetition.StatisticsOddByMatch.Select(x => new StatisticOddByMatch()
            {
                CompetitionId = competition.Id,
                MatchNumber = x.MatchNumber,
                Odd = x.Odd,
                OverUnder = x.OverUnder,
                Quantity = x.Quantity,
                QuantityEvents = events.Count(z => z.Match?.Number == x.MatchNumber)
            }));
            _eventBus.Publish(statistic);
        }

        private async Task<IEnumerable<StatisticOddByMatch>> BothTeamsScore(IEnumerable<Match> matches)
        {
            var statistics = new List<StatisticOddByMatch>();
            foreach (var match in matches)
            {
                var quantity = 0;
                var goals = await _statisticRepository.GetGoalsByMatchAsync(match.Id);
                var events = goals.GroupBy(x => x.EventId);
                foreach (var theEvent in events)
                {
                    var eventGoals = goals.Where(x => x.EventId == theEvent.Key).GroupBy(z => z.TeamId).Count() > 1;
                    if (eventGoals)
                    {
                        quantity++;
                    }
                }
                statistics.Add(new StatisticOddByMatch()
                {
                    Odd = Odd.BothTeamsScore,
                    MatchNumber = match.Number,
                    OverUnder = null,
                    Quantity = quantity
                });
            }

            return statistics.AsEnumerable();
        }

        private async Task<IEnumerable<StatisticOddByMatch>> GoalsOverOrUnder(IEnumerable<Match> matches)
        {
            var statistics = new List<StatisticOddByMatch>();        
            var odds = new double[] { 0.5, 1.5, 2.5, 3.5, 4.5, 5.5, 6.5, 7.5, 8.5, 9.5 };
            foreach (var item in odds)
            {
                foreach (var match in matches)
                {
                    var quantity = 0;
                    var goals = await _statisticRepository.GetGoalsByMatchAsync(match.Id);
                    var events = goals.GroupBy(x => x.EventId);
                    foreach (var theEvent in events)
                    {
                        if (theEvent.Count() > item)
                        {
                            quantity++;
                        }
                    }
                    statistics.Add(new StatisticOddByMatch()
                    {
                        Odd = Odd.GoalsOverOrUnder,
                        MatchNumber = match.Number,
                        OverUnder = item,
                        Quantity = quantity
                    });
                }
            }
            return statistics.AsEnumerable();
        }

        private IEnumerable<StatisticOddByMatch> GoalsOverOrUnderFirstHalf(IEnumerable<Match> matches, IEnumerable<MatchEvent> goals)
        {
            var statistics = new List<StatisticOddByMatch>();
            var odds = new double[] { 0.5, 1.5, 2.5, 3.5, 4.5, 5.5, 6.5, 7.5, 8.5, 9.5 };
            foreach (var item in odds)
            {
                foreach (var match in matches)
                {
                    var quantity = 0;
                    var goalsFirstHalf = goals.Where(x => x.Elapsed <= 45 && x.TheEvent.MatchId == match.Id);
                    var events = goals.GroupBy(x => x.EventId);
                    foreach (var theEvent in events)
                    {
                        if (theEvent.Count() > item)
                        {
                            quantity++;
                        }
                    }
                    statistics.Add(new StatisticOddByMatch()
                    {
                        Odd = Odd.GoalsOverOrUnderFirstHalf,
                        MatchNumber = match.Number,
                        OverUnder = item,
                        Quantity = quantity
                    });
                }
            }
            return statistics.AsEnumerable();
        }

        private IEnumerable<StatisticOddByMatch> GoalsOverOrUnderSecondHalf(IEnumerable<Match> matches, IEnumerable<MatchEvent> goals)
        {
            var statistics = new List<StatisticOddByMatch>();
            var odds = new double[] { 0.5, 1.5, 2.5, 3.5, 4.5, 5.5, 6.5, 7.5, 8.5, 9.5 };
            foreach (var item in odds)
            {
                foreach (var match in matches)
                {
                    var quantity = 0;
                    var goalsSecondHalf = goals.Where(x => x.Elapsed > 45 && x.TheEvent.MatchId == match.Id);
                    var events = goals.GroupBy(x => x.EventId);
                    foreach (var theEvent in events)
                    {
                        if (theEvent.Count() > item)
                        {
                            quantity++;
                        }
                    }
                    statistics.Add(new StatisticOddByMatch()
                    {
                        Odd = Odd.GoalsOverOrUnderSecondHalf,
                        MatchNumber = match.Number,
                        OverUnder = item,
                        Quantity = quantity
                    });
                }
            }
            return statistics.AsEnumerable();
        }

        private IEnumerable<StatisticOddByMatch> CornersOverUnder(IEnumerable<Match> matches, IEnumerable<Statistic> statistics)
        {
            var result = new List<StatisticOddByMatch>();
            var odds = new double[] { 4.5, 5.5, 6.5, 7.5, 8.5, 9.5, 10.5, 11.5, 12.5, 13.5, 14.5, 15.5, 16.5, 17.5, 18.5, 19.5, 20.5 };
            foreach (var item in odds)
            {
                foreach (var match in matches)
                {
                    var statisticsMatch = statistics.Where(x => x.TheEvent.MatchId == match.Id);
                    var events = statisticsMatch.GroupBy(x => x.EventId);
                    var quantity = events.Count(x => x.Sum(z => z.CornerKicks) > item);
                    result.Add(new StatisticOddByMatch()
                    {
                        Odd = Odd.CornersOverUnder,
                        MatchNumber = match.Number / 2,
                        OverUnder = item,
                        Quantity = quantity
                    });
                }
            }
            return result.AsEnumerable();
        }
    }

    public class StatisticCompetition
    {
        public Competition Competition { get; set; }
        public List<StatisticOddByMatch> StatisticsOddByMatch { get; set; }
        public IEnumerable<SoccerEvent> NextEvents { get; set; }
    }
}
