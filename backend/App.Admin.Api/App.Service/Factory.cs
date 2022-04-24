using App.Domain.Models;
using App.Domain.Models.Enum;
using App.Models;
using App.Service.ViewModels;
using App.Service.ViewModels.SoccerEvent;
using App.Service.ViewModels.SoccerTeam;
using App.Service.ViewModels.Statistic;
using System;
using System.Collections.Generic;

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

            //entity.MatchId = vm.MatchId;
            entity.Match = new Match() { CompetitionId = vm.CompetitionId, Number = vm.MatchNumber };
            entity.Date = vm.Date;
            entity.HomeTeamId = vm.HomeTeamId;
            entity.OutTeamId = vm.OutTeamId;
            entity.Referee = vm.Referee;
            entity.Venue = vm.Venue;
            //entity.Match = vm.Match.ToEntity();

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

        public static SoccerTeamEventVM ToSoccerTeamEventVM(this SoccerTeam entity)
        {
            var vm = new SoccerTeamEventVM();
            if (entity is null)
                return vm;

            vm.Id = entity.Id;
            vm.Country = entity.Country;
            vm.Image = entity.Image;
            vm.Name = entity.Name;

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

            entity.EventTimeStatistic = vm.EventTimeStatistic.ToEntity();
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

            entity.EventTimeStatistic = vm.EventTimeStatistic.ToEntity();
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

            entity.EventTimeStatistic = vm.EventTimeStatistic.ToEntity();
            entity.EventTimeStatisticId = vm.EventTimeStatisticId;
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

        public static EventTimeStatistic ToEntity(this EventTimeStatisticVM vm)
        {
            var entity = new EventTimeStatistic();
            if (vm is null)
                return entity;

            entity.Id = vm.Id;
            entity.Half = (SoccerTimers)vm.Half;
            entity.EventId = vm.EventId;
            entity.SoccerTeamId = vm.SoccerTeamId;

            return entity;
        }
    }
}
