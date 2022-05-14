using App.Domain.Exceptions.SoccerTeam;
using App.Domain.Interfaces;
using App.Service.Interfaces;
using App.Service.ViewModels.SoccerTeam;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service
{
    public class SoccerTeamService : ISoccerTeamService
    {
        private readonly ISoccerTeamRepository _repository;

        public SoccerTeamService(ISoccerTeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(AddSoccerTeamVM vm)
        {
            try
            {
                var entity = vm.ToEntity();
                entity.Created = DateTime.Now;
                entity.Updated = DateTime.Now;
                return await _repository.AddAsync(entity);
            }
            catch (AddSoccerTeamException ex)
            {
                throw new AddSoccerTeamException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new AddSoccerTeamException(ex.Message, ex);
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SoccerTeamVM>> FilterAsync(string filter)
        {
            try
            {
                var result = await _repository.FilterAsync(filter);
                return result.ToVM();
            }
            catch (QuerySoccerTeamException ex)
            {
                throw new QuerySoccerTeamException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new QuerySoccerTeamException(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<SoccerTeamVM>> GetAsync()
        {
            try
            {
                var result = await _repository.GetAsync();
                return result.ToVM();
            }
            catch (QuerySoccerTeamException ex)
            {
                throw new QuerySoccerTeamException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new QuerySoccerTeamException(ex.Message, ex);
            }
        }

        public async Task<SoccerTeamVM> GetAsync(int id)
        {
            try
            {
                var result = await _repository.GetAsync(id);
                return result.ToVM();
            }
            catch (QuerySoccerTeamException ex)
            {
                throw new QuerySoccerTeamException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new QuerySoccerTeamException(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateAsync(UpdateSoccerTeamVM vm)
        {
            try
            {
                var entity = vm.ToEntity();
                entity.Updated = DateTime.Now;
                var quantityAffected = await _repository.UpdateAsync(entity);
                return quantityAffected > 0;
            }
            catch (UpdateSoccerTeamException ex)
            {
                throw new UpdateSoccerTeamException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new UpdateSoccerTeamException(ex.Message, ex);
            }
        }
    }
}
