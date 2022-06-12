using App.Domain.Interfaces;
using App.Domain.Models;
using App.EventBus.IntegrationEvents.EventHandling;
using App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.Services
{
    public class FixtureStatisticIntegrationEventService : IFixtureStatisticIntegrationEventService
    {
        private readonly IApiValueReferenceRepository _referenceRepository;
        private readonly IStatisticRepository _statisticRepository;

        public FixtureStatisticIntegrationEventService(IApiValueReferenceRepository referenceRepository,
            IStatisticRepository statisticRepository)
        {
            _referenceRepository = referenceRepository;
            _statisticRepository = statisticRepository;
        }

        public async Task<bool> AddOrUpdateAsync(List<FixtureStatisticsResponseVM> vm, long id)
        {
            foreach (var item in vm)
            {
                var fixture = await _referenceRepository.GetByApiIdAsync("EVENTS", (int)id);
                var team = await _referenceRepository.GetByApiIdAsync("TEAMS", item.Team.Id.Value);
                if(fixture != null && team != null)
                {
                    var ballPossession = item.Statistics.FirstOrDefault(x => x.Type == "Ball Possession");
                    var shotsOnGoal = item.Statistics.FirstOrDefault(x => x.Type == "Shots on Goal");
                    var shotsOffGoal = item.Statistics.FirstOrDefault(x => x.Type == "Shots off Goal");
                    var blockedShots = item.Statistics.FirstOrDefault(x => x.Type == "Blocked Shots");
                    var cornerKicks = item.Statistics.FirstOrDefault(x => x.Type == "Corner Kicks");
                    var offsides = item.Statistics.FirstOrDefault(x => x.Type == "Offsides");
                    var goalkeeperSaves = item.Statistics.FirstOrDefault(x => x.Type == "Goalkeeper Saves");
                    var fouls = item.Statistics.FirstOrDefault(x => x.Type == "Fouls");
                    var yellowCards = item.Statistics.FirstOrDefault(x => x.Type == "Yellow Cards");
                    var redCards = item.Statistics.FirstOrDefault(x => x.Type == "Red Cards");
                    var totalPasses = item.Statistics.FirstOrDefault(x => x.Type == "Total passes");
                    var statistic = new Statistic()
                    {
                        TeamId = team.AppId,
                        EventId = fixture.AppId,
                        Period = "FULL",
                        BallPossession = ballPossession != null && !string.IsNullOrEmpty(ballPossession.Value) ? int.Parse(ballPossession.Value.Replace("%", "")) : null,
                        ShotsOnGoal = shotsOnGoal != null && !string.IsNullOrEmpty(shotsOnGoal.Value) ? int.Parse(shotsOnGoal.Value) : null,
                        ShotsOffGoal = shotsOffGoal != null && !string.IsNullOrEmpty(shotsOffGoal.Value) ? int.Parse(shotsOffGoal.Value) : null,
                        BlockedShots = blockedShots != null && !string.IsNullOrEmpty(blockedShots.Value) ? int.Parse(blockedShots.Value) : null,
                        CornerKicks = cornerKicks != null && !string.IsNullOrEmpty(cornerKicks.Value) ? int.Parse(cornerKicks.Value) : null,
                        Offsides = offsides != null && !string.IsNullOrEmpty(offsides.Value) ? int.Parse(offsides.Value) : null,
                        GoalkeeperSaves = goalkeeperSaves != null && !string.IsNullOrEmpty(goalkeeperSaves.Value) ? int.Parse(goalkeeperSaves.Value) : null,
                        Fouls = fouls != null && !string.IsNullOrEmpty(fouls.Value) ? int.Parse(fouls.Value) : null,
                        YellowCards = yellowCards != null && !string.IsNullOrEmpty(yellowCards.Value) ? int.Parse(yellowCards.Value) : null,
                        RedCards = redCards != null && !string.IsNullOrEmpty(redCards.Value) ? int.Parse(redCards.Value) : null,
                        TotalPasses = totalPasses != null && !string.IsNullOrEmpty(totalPasses.Value) ? int.Parse(totalPasses.Value) : null,
                    };
                    var has = await _statisticRepository.HasAsync(statistic.EventId.Value, statistic.TeamId, statistic.Period);
                    if (has == null)
                    {
                        await _statisticRepository.AddAsync(statistic);
                    }
                }
            }
            return true;
        }
    }
}
