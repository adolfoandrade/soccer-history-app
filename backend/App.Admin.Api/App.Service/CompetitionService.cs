using App.Domain.Exceptions.Competition;
using App.Domain.Interfaces;
using App.Service.Interfaces;
using App.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ICompetitionRepository _repository;

        public CompetitionService(ICompetitionRepository repository)
        {
            _repository = repository;
        }

        public async Task<CompetitionVM> AddAsync(CompetitionVM vm)
        {
            var entity = vm.ToEntity();
            try
            {
                await _repository.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new AddCompetitionException(ex.Message, ex);
            }
            return entity.ToVM();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var quantity = await _repository.DeleteAsync(id);
                return quantity > 0;
            }
            catch (DeleteCompetitionException ex)
            {
                throw new DeleteCompetitionException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new DeleteCompetitionException(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<CompetitionVM>> GetBySeasonAsync(string season)
        {
            try
            {
                var competitions = await _repository.GetBySeasonAsync(season);
                var vm = competitions.ToVM();
                return vm;
            }
            catch (QueryCompetitionBySeasonException ex)
            {
                throw new QueryCompetitionBySeasonException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new QueryCompetitionBySeasonException(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateAsync(CompetitionVM vm)
        {
            if (vm.Id < 1)
            {
                throw new CompetitionNotFoundException($"Invalid value on field id {vm.Id}");
            }
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
                var competition = await _repository.UpdateAsync(entity);
                return competition > 0;
            }
            catch (UpdateCompetitionException ex)
            {
                throw new UpdateCompetitionException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new UpdateCompetitionException(ex.Message, ex);
            }
        }

    }
}
