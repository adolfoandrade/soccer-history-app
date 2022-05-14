using App.Domain.Models;
using App.Domain.Models.Enum;
using App.Models;
using App.Service.ViewModels;
using App.Service.ViewModels.SoccerEvent;
using App.Service.ViewModels.SoccerTeam;
using App.Service.ViewModels.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Service
{
    public static class Factory
    {
        public static List<CompetitionVM> ToVM(this IEnumerable<Competition> competitions)
        {
            var vm = new List<CompetitionVM>();
            foreach (var competition in competitions)
            {
                vm.Add(competition.ToVM());
            }
            return vm;
        }

        public static CompetitionVM ToVM(this Competition competition)
        {
            var vm = new CompetitionVM();

            if (competition is null)
                return null;

            vm.Id = competition.Id;
            vm.Name = competition.Name;
            vm.Country = competition.Country;
            vm.Image = competition.Image;
            vm.Year = competition.Year;

            return vm;
        }

        public static Competition ToEntity(this CompetitionVM vm)
        {
            var entity = new Competition();
            if (vm is null)
                return entity;

            entity.Id = vm.Id;
            entity.Name = vm.Name;
            entity.Country = vm.Country;
            entity.Image = vm.Image;
            entity.Year = vm.Year;
            entity.Created = DateTime.Now;
            entity.Updated = DateTime.Now;

            return entity;
        }

        public static SoccerEvent ToEntity(this AddSoccerEventVM vm)
        {
            var entity = new SoccerEvent();
            if (vm is null)
                return entity;

            entity.Match = new Match() { CompetitionId = vm.CompetitionId, Number = vm.MatchNumber };
            entity.Date = vm.Date;
            entity.HomeTeamId = vm.HomeTeamId;
            entity.OutTeamId = vm.OutTeamId;
            entity.Referee = vm.Referee;
            entity.Venue = vm.Venue;

            return entity;
        }

        public static SoccerEvent ToEntity(this UpdateSoccerEventVM vm)
        {
            var entity = new SoccerEvent();
            if (vm is null)
                return entity;

            entity.Id = vm.Id;
            entity.MatchId = vm.MatchId;
            entity.Date = vm.Date;
            entity.HomeTeamId = vm.HomeTeamId;
            entity.OutTeamId = vm.OutTeamId;
            entity.Referee = vm.Referee;
            entity.Venue = vm.Venue;
            entity.Match = vm.Match.ToEntity();

            return entity;
        }

        public static List<SoccerEventVM> ToVM(this IEnumerable<SoccerEvent> entities)
        {
            var vm = new List<SoccerEventVM>();
            foreach (var entity in entities)
            {
                vm.Add(entity.ToVM());
            }
            return vm;
        }

        public static SoccerEventVM ToVM(this SoccerEvent entity)
        {
            var vm = new SoccerEventVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.MatchId = entity.MatchId;
            vm.Date = entity.Date;
            vm.HomeTeamId = entity.HomeTeamId;
            vm.OutTeamId = entity.OutTeamId;
            vm.Referee = entity.Referee;
            vm.Venue = entity.Venue;
            vm.Home = entity.Home.ToSoccerTeamEventVM();
            vm.Out = entity.Out.ToSoccerTeamEventVM();

            return vm;
        }

        public static SoccerEventDetailsVM ToDetailsVM(this SoccerEvent entity)
        {
            var vm = new SoccerEventDetailsVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.MatchId = entity.MatchId;
            vm.Date = entity.Date;
            vm.HomeTeamId = entity.HomeTeamId;
            vm.OutTeamId = entity.OutTeamId;
            vm.Referee = entity.Referee;
            vm.Venue = entity.Venue;
            vm.Home = entity.Home.ToSoccerTeamEventVM();
            vm.Out = entity.Out.ToSoccerTeamEventVM();

            var goals = entity.EventTimeStatistics.Where(x => x.Goal != null && x.Goal.Id > 0).ToEventGoalVM().ToTimeLineVM();
            var cards = entity.EventTimeStatistics.Where(x => x.Card != null && x.Card.Id > 0).ToEventCardVM().ToTimeLineVM();
            vm.TimeLine = new List<EventTimeLineVM>();
            vm.TimeLine.AddRange(goals);
            vm.TimeLine.AddRange(cards);
            vm.TimeLine = vm.TimeLine.OrderByDescending(x => x.Item.Minute).ToList();
            vm.Home.Goals = goals.Count(x => x.SoccerTeam.Id == vm.Home.Id);
            vm.Out.Goals = goals.Count(x => x.SoccerTeam.Id == vm.Out.Id);

            vm.Statistics = entity.EventTimeStatistics.Where(x => x.Statistic != null && x.Statistic.Id > 0).ToEventStatisticVM();
            var fullStatisticHomeTeam = vm.Statistics.GetFullStatistic(entity.Home);
            var fullStatisticAwayTeam = vm.Statistics.GetFullStatistic(entity.Out);
            vm.Statistics.Add(fullStatisticHomeTeam);
            vm.Statistics.Add(fullStatisticAwayTeam);       

            return vm;
        }

        public static EventStatisticVM GetFullStatistic(this IEnumerable<EventStatisticVM> entities, SoccerTeam team)
        {
            var vm = new EventStatisticVM();

            entities = entities.Where(x => x.SoccerTeam.Id == team.Id);
            vm.Id = 99999999;
            vm.Half = "FULL";
            vm.SoccerTeam = team.ToVM();
            vm.Statistic = new StatisticVM();
            vm.Statistic.BallPossession = entities.Sum(x => x.Statistic.BallPossession);
            vm.Statistic.GoalAttempts = entities.Sum(x => x.Statistic.GoalAttempts);
            vm.Statistic.ShotsOnGoal = entities.Sum(x => x.Statistic.ShotsOnGoal);
            vm.Statistic.ShotsOffGoal = entities.Sum(x => x.Statistic.ShotsOffGoal);
            vm.Statistic.BlockedShots = entities.Sum(x => x.Statistic.BlockedShots);
            vm.Statistic.CornerKicks = entities.Sum(x => x.Statistic.CornerKicks);
            vm.Statistic.FreeKicks = entities.Sum(x => x.Statistic.FreeKicks);
            vm.Statistic.Offsides = entities.Sum(x => x.Statistic.Offsides);
            vm.Statistic.Throwin = entities.Sum(x => x.Statistic.Throwin);
            vm.Statistic.GoalkeeperSaves = entities.Sum(x => x.Statistic.GoalkeeperSaves);
            vm.Statistic.Fouls = entities.Sum(x => x.Statistic.Fouls);
            vm.Statistic.YellowCards = entities.Sum(x => x.Statistic.YellowCards);
            vm.Statistic.RedCards = entities.Sum(x => x.Statistic.RedCards);
            vm.Statistic.TotalPasses = entities.Sum(x => x.Statistic.TotalPasses);
            vm.Statistic.CompletedPasses = entities.Sum(x => x.Statistic.CompletedPasses);
            vm.Statistic.Trackles = entities.Sum(x => x.Statistic.Trackles);
            vm.Statistic.Attacks = entities.Sum(x => x.Statistic.Attacks);
            vm.Statistic.DangerousAttacks = entities.Sum(x => x.Statistic.DangerousAttacks);

            return vm;
        }

        public static List<EventTimeLineVM> ToTimeLineVM(this IEnumerable<EventGoalVM> entities)
        {
            var vm = new List<EventTimeLineVM>();
            foreach (var entity in entities)
            {
                vm.Add(entity.ToTimeLineItemVM());
            }
            return vm;
        }

        public static List<EventTimeLineVM> ToTimeLineVM(this IEnumerable<EventCardVM> entities)
        {
            var vm = new List<EventTimeLineVM>();
            foreach (var entity in entities)
            {
                vm.Add(entity.ToTimeLineItemVM());
            }
            return vm;
        }

        public static EventTimeLineVM ToTimeLineItemVM(this EventGoalVM entity)
        {
            var vm = new EventTimeLineVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Half = entity.Half.ToString();
            vm.SoccerTeam = entity.SoccerTeam;
            vm.Item = entity.Goal.ToTimeLineItemVM();

            return vm;
        }

        public static EventTimeLineVM ToTimeLineItemVM(this EventCardVM entity)
        {
            var vm = new EventTimeLineVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Half = entity.Half.ToString();
            vm.SoccerTeam = entity.SoccerTeam;
            vm.Item = entity.Card.ToTimeLineItemVM();

            return vm;
        }

        public static TimeLineItemVM ToTimeLineItemVM(this SoccerTeamEventGolVM entity)
        {
            var vm = new TimeLineItemVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Type = "GOAL";
            vm.Assist = entity.Assist;
            vm.Player = entity.Player;
            vm.Minute = entity.Minute;

            return vm;
        }

        public static TimeLineItemVM ToTimeLineItemVM(this SoccerTeamEventCardVM entity)
        {
            var vm = new TimeLineItemVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Type = "CARD";
            vm.Color = entity.Color;
            vm.Player = entity.Player;
            vm.Minute = entity.Minute;

            return vm;
        }

        public static List<EventStatisticVM> ToEventStatisticVM(this IEnumerable<EventTimeStatistic> entities)
        {
            var vm = new List<EventStatisticVM>();
            foreach (var entity in entities)
            {
                vm.Add(entity.ToStatisticVM());
            }
            return vm;
        }

        public static EventStatisticVM ToStatisticVM(this EventTimeStatistic entity)
        {
            var vm = new EventStatisticVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Half = entity.Half.ToString();
            vm.SoccerTeam = entity.SoccerTeam.ToVM();
            vm.Statistic = entity.Statistic.ToVM();

            return vm;
        }

        public static List<EventCardVM> ToEventCardVM(this IEnumerable<EventTimeStatistic> entities)
        {
            var vm = new List<EventCardVM>();
            foreach (var entity in entities)
            {
                vm.Add(entity.ToCardVM());
            }
            return vm;
        }

        public static EventCardVM ToCardVM(this EventTimeStatistic entity)
        {
            var vm = new EventCardVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Half = entity.Half.ToString();
            vm.SoccerTeam = entity.SoccerTeam.ToVM();
            vm.Card = entity.Card.ToVM();

            return vm;
        }

        public static List<EventGoalVM> ToEventGoalVM(this IEnumerable<EventTimeStatistic> entities)
        {
            var vm = new List<EventGoalVM>();
            foreach (var entity in entities)
            {
                vm.Add(entity.ToGoalVM());
            }
            return vm;
        }

        public static EventGoalVM ToGoalVM(this EventTimeStatistic entity)
        {
            var vm = new EventGoalVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Half = entity.Half.ToString();
            vm.SoccerTeam = entity.SoccerTeam.ToVM();
            vm.Goal = entity.Goal.ToVM();

            return vm;
        }

        public static SoccerTeamEventGolVM ToGoalVM(this SoccerTeamEventGol entity)
        {
            var vm = new SoccerTeamEventGolVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Assist = entity.Assist;
            vm.Player = entity.Player;
            vm.Minute = entity.Minute;

            return vm;
        }

        public static EventTimeStatisticVM ToVM(this EventTimeStatistic entity)
        {
            var vm = new EventTimeStatisticVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Half = entity.Half.ToString();
            vm.SoccerTeam = entity.SoccerTeam.ToVM();
            vm.SoccerTeamId = entity.SoccerTeamId;
            vm.EventId = entity.EventId;
            vm.Goal = entity.Goal.ToVM();
            vm.Card = entity.Card.ToVM();
            vm.Statistic = entity.Statistic.ToVM();

            return vm;
        }

        public static StatisticVM ToVM(this Statistic entity)
        {
            var vm = new StatisticVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.BallPossession = entity.BallPossession;
            vm.GoalAttempts = entity.GoalAttempts;
            vm.ShotsOnGoal = entity.ShotsOnGoal;
            vm.ShotsOffGoal = entity.ShotsOffGoal;
            vm.BlockedShots = entity.BlockedShots;
            vm.CornerKicks = entity.CornerKicks;
            vm.FreeKicks = entity.FreeKicks;
            vm.Offsides = entity.Offsides;
            vm.Throwin = entity.Throwin;
            vm.GoalkeeperSaves = entity.GoalkeeperSaves;
            vm.Fouls = entity.Fouls;
            vm.YellowCards = entity.YellowCards;
            vm.RedCards = entity.RedCards;
            vm.TotalPasses = entity.TotalPasses;
            vm.CompletedPasses = entity.CompletedPasses;
            vm.Trackles = entity.Trackles;
            vm.Attacks = entity.Attacks;
            vm.DangerousAttacks = entity.DangerousAttacks;

            return vm;
        }

        public static SoccerTeamEventCardVM ToVM(this SoccerTeamEventCard entity)
        {
            var vm = new SoccerTeamEventCardVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Color = entity.Color;
            vm.Minute = entity.Minute;
            vm.Player = entity.Player;

            return vm;
        }

        public static SoccerTeamEventGolVM ToVM(this SoccerTeamEventGol entity)
        {
            var vm = new SoccerTeamEventGolVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Assist = entity.Assist;
            vm.Minute = entity.Minute;
            vm.Player = entity.Player;

            return vm;
        }

        public static SoccerTeamEventVM ToSoccerTeamEventVM(this SoccerTeam entity)
        {
            var vm = new SoccerTeamEventVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Country = entity.Country;
            vm.Image = entity.Image;
            vm.Name = entity.Name;
            vm.ColorTheme = entity.ColorTheme;
            vm.SecondColorTheme = entity.SecondColorTheme;

            return vm;
        }

        public static SoccerTeamVM ToVM(this SoccerTeam entity)
        {
            var vm = new SoccerTeamVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Country = entity.Country;
            vm.Image = entity.Image;
            vm.Name = entity.Name;
            vm.ColorTheme = entity.ColorTheme;
            vm.SecondColorTheme = entity.SecondColorTheme;
            vm.Created = entity.Created;
            vm.Updated = entity.Updated;

            return vm;
        }

        public static List<SoccerTeamVM> ToVM(this IEnumerable<SoccerTeam> entities)
        {
            var vm = new List<SoccerTeamVM>();
            foreach (var entity in entities)
            {
                vm.Add(entity.ToVM());
            }
            return vm;
        }

        public static SoccerTeam ToEntity(this AddSoccerTeamVM vm)
        {
            var entity = new SoccerTeam();
            if (vm is null)
                return entity;

            entity.Country = vm.Country;
            entity.Image = vm.Image;
            entity.Name = vm.Name;
            entity.ColorTheme = vm.ColorTheme;
            entity.SecondColorTheme = vm.SecondColorTheme;
            entity.Created = vm.Created;
            entity.Updated = vm.Updated;

            return entity;
        }

        public static SoccerTeam ToEntity(this UpdateSoccerTeamVM vm)
        {
            var entity = new SoccerTeam();
            if (vm is null)
                return entity;

            entity.Id = vm.Id;
            entity.Country = vm.Country;
            entity.Image = vm.Image;
            entity.Name = vm.Name;
            entity.ColorTheme = vm.ColorTheme;
            entity.SecondColorTheme = vm.SecondColorTheme;
            entity.Created = vm.Created;
            entity.Updated = vm.Updated;

            return entity;
        }

        public static MatchVM ToVM(this Match vm)
        {
            var entity = new MatchVM();
            if (vm is null)
                return entity;

            entity.Id = vm.Id;
            entity.Number = vm.Number;
            entity.Letter = vm.Letter;
            entity.Stage = vm.Stage;
            entity.CompetitionId = vm.CompetitionId;

            return entity;
        }

        public static Match ToEntity(this MatchVM vm)
        {
            var entity = new Match();
            if (vm is null)
                return entity;

            entity.Id = vm.Id;
            entity.Number = vm.Number;
            entity.Letter = vm.Letter;
            entity.Stage = vm.Stage;
            entity.CompetitionId = vm.CompetitionId;

            return entity;
        }

        public static SoccerTeamEventGol ToEntity(this AddStatisticGoalsVM vm)
        {
            var entity = new SoccerTeamEventGol();
            if (vm is null)
                return entity;

            Enum.TryParse(vm.Half, out SoccerTimers half);
            entity.EventTimeStatistic = new EventTimeStatistic() { SoccerTeamId = vm.SoccerTeamId, Half = half, EventId = vm.EventId };
            entity.Minute = vm.Minute;
            entity.Player = vm.Player;
            entity.Assist = vm.Assist;
            entity.EventTimeStatisticId = vm.EventTimeStatisticId;

            return entity;
        }

        public static SoccerTeamEventCard ToEntity(this AddStatisticCardsVM vm)
        {
            var entity = new SoccerTeamEventCard();
            if (vm is null)
                return entity;

            Enum.TryParse(vm.Half, out SoccerTimers half);
            entity.EventTimeStatistic = new EventTimeStatistic() { SoccerTeamId = vm.SoccerTeamId, Half = half, EventId = vm.EventId };
            entity.Minute = vm.Minute;
            entity.Player = vm.Player;
            entity.Color = vm.Color;
            entity.EventTimeStatisticId = vm.EventTimeStatisticId;

            return entity;
        }

        public static Statistic ToEntity(this AddCommonStatisticVM vm)
        {
            var entity = new Statistic();
            if (vm is null)
                return entity;

            Enum.TryParse(vm.Half, out SoccerTimers half);
            entity.EventTimeStatistic = new EventTimeStatistic() { SoccerTeamId = vm.SoccerTeamId, Half = half, EventId = vm.EventId };
            entity.BallPossession = vm.BallPossession;
            entity.GoalAttempts = vm.GoalAttempts;
            entity.ShotsOnGoal = vm.ShotsOnGoal;
            entity.ShotsOffGoal = vm.ShotsOffGoal;
            entity.BlockedShots = vm.BlockedShots;
            entity.CornerKicks = vm.CornerKicks;
            entity.FreeKicks = vm.FreeKicks;
            entity.Offsides = vm.Offsides;
            entity.Throwin = vm.Throwin;
            entity.GoalkeeperSaves = vm.GoalkeeperSaves;
            entity.Fouls = vm.Fouls;
            entity.YellowCards = vm.YellowCards;
            entity.RedCards = vm.RedCards;
            entity.TotalPasses = vm.TotalPasses;
            entity.CompletedPasses = vm.CompletedPasses;
            entity.Trackles = vm.Trackles;
            entity.Attacks = vm.Attacks;
            entity.DangerousAttacks = vm.DangerousAttacks;

            return entity;
        }

        public static Domain.Models.EventTimeStatistic ToEntity(this ViewModels.Statistic.EventTimeStatisticVM vm)
        {
            var entity = new Domain.Models.EventTimeStatistic();
            if (vm is null)
                return entity;

            entity.Id = vm.Id;
            Enum.TryParse(vm.Half, out SoccerTimers half);
            entity.Half = half;
            entity.EventId = vm.EventId;
            entity.SoccerTeamId = vm.SoccerTeamId;

            return entity;
        }
    }
}
