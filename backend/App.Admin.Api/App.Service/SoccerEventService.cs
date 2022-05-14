using App.Domain.Exceptions.SoccerEvent;
using App.Domain.Interfaces;
using App.Models;
using App.Service.Interfaces;
using App.Service.ViewModels;
using App.Service.ViewModels.SoccerEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Service
{
    public class SoccerEventService : ISoccerEventService
    {
        private readonly ISoccerEventRepository _repository;
        private readonly IMatchRepository _matchRepository;
        private readonly ICompetitionRepository _competitionRepository;

        public SoccerEventService(ISoccerEventRepository repository,
            IMatchRepository matchRepository,
            ICompetitionRepository competitionRepository)
        {
            _repository = repository;
            _matchRepository = matchRepository;
            _competitionRepository = competitionRepository;
        }

        public async Task<int> AddAsync(AddSoccerEventVM vm)
        {
            var entity = vm.ToEntity();
            try
            {
                var match = await _matchRepository.GetByMatchNumerAsync(vm.MatchNumber, vm.CompetitionId);
                if(match is null)
                {
                    match = new Match { CompetitionId = vm.CompetitionId, Number = vm.MatchNumber };
                    await _matchRepository.AddAsync(match);
                    match = await _matchRepository.GetByMatchNumerAsync(vm.MatchNumber, vm.CompetitionId);
                }
                entity.MatchId = match.Id;
                entity.Match = match;
                return await _repository.AddAsync(entity);
            }
            catch (QueryMatchException ex)
            {
                throw new AddSoccerEventException(ex.Message, ex);
            }
            catch (AddSoccerEventException ex)
            {
                throw new AddSoccerEventException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new AddSoccerEventException(ex.Message, ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var quantity = await _repository.DeleteAsync(id);
                return quantity > 0;
            }
            catch (DeleteSoccerEventException ex)
            {
                throw new DeleteSoccerEventException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new DeleteSoccerEventException(ex.Message, ex);
            }
        }

        public Task<FilterEventResultVM> Filter(EventFilterVM vm)
        {
            throw new NotImplementedException();
        }

        public async Task<SoccerEventDetailsVM> GetAsync(int id)
        {
            try
            {
                var @event = await _repository.GetAsync(id);
                var vm = @event.ToDetailsVM();
                return vm;
            }
            catch (QuerySoccerEventException ex)
            {
                throw new QuerySoccerEventException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new QuerySoccerEventException(ex.Message, ex);
            }
        }

        public async Task<SoccerEventMatchVM> GetByMatchAsync(string match, int competitionId)
        {
            try
            {
                var theMatch = await _matchRepository.GetByMatchNumerAsync(int.Parse(match), competitionId);
                var events = await _repository.GetByMatchAsync(match);
                var vm = new SoccerEventMatchVM();
                vm.Match = theMatch.ToVM();
                vm.Events = events.ToVM();
                return vm;
            }
            catch (QueryByMatchSoccerEventException ex)
            {
                throw new QueryByMatchSoccerEventException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new QueryByMatchSoccerEventException(ex.Message, ex);
            }
        }

        public async Task<SoccerEventSeasonVM> GetBySeasonAsync(int competitionId, string season)
        {
            try
            {
                var vm = new SoccerEventSeasonVM();
                var competitions = await _competitionRepository.GetBySeasonAsync(season);
                var theCompetition = competitions.FirstOrDefault(x => x.Id == competitionId);
                var seasonEvents = await _repository.GetBySeasonAsync(theCompetition.Id);
                var matches = seasonEvents.Select(x => x.Match)
                                            .Where(x => x != null)
                                            .GroupBy(x => x.Number)
                                            .Select(g => g.First())
                                            .ToList();
                vm.Season = theCompetition.ToVM();
                var @events = new List<SoccerEventMatchVM>();
                foreach (var match in matches)
                {
                    @events.Add(new SoccerEventMatchVM()
                    {
                        Match = match.ToVM(),
                        Events = seasonEvents.Where(x => x.MatchId == match.Id).ToVM()
                    });
                }
                vm.Matches = @events.OrderByDescending(x => x.Match.Number).ToList();
                return vm;
            }
            catch (QueryBySeasonSoccerEventException ex)
            {
                throw new QueryBySeasonSoccerEventException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new QueryBySeasonSoccerEventException(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateAsync(UpdateSoccerEventVM vm)
        {
            //if (vm.Id < 1)
            //{
            //    throw new CompetitionNotFoundException($"Invalid value on field id {vm.Id}");
            //}
            //Competition any = null;
            //try
            //{
            //    any = await _repository.GetAsync(1);
            //}
            //catch (Exception ex)
            //{
            //    throw new QueryCompetitionBySeasonException(ex.Message, ex);
            //}
            //if (any is null)
            //{
            //    throw new QueryCompetitionBySeasonException($"Competition requested not found");
            //}
            try
            {
                var entity = vm.ToEntity();
                var @event = await _repository.UpdateAsync(entity);
                return @event > 0;
            }
            catch (UpdateSoccerEventException ex)
            {
                throw new UpdateSoccerEventException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new UpdateSoccerEventException(ex.Message, ex);
            }
        }
    }
}
