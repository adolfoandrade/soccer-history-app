using App.Domain.Exceptions.SoccerTeamEventGoal;
using App.Domain.Interfaces;
using App.Service.Interfaces;
using App.Service.ViewModels.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public class StatisticGoalsService : IStatisticGoalsService
    {
        private readonly ISoccerTeamEventGolRepository _repository;
        private readonly IEventTimeStatisticRepository _eventTimeStatisticRepository;

        public StatisticGoalsService(ISoccerTeamEventGolRepository repository,
            IEventTimeStatisticRepository eventTimeStatisticRepository)
        {
            _repository = repository;
            _eventTimeStatisticRepository = eventTimeStatisticRepository;
        }

        public async Task<int> AddAsync(AddStatisticGoalsVM vm)
        {
            try
            {
                var entity = vm.ToEntity();
                if(entity.EventTimeStatistic.Id <= 0 || entity.EventTimeStatisticId <= 0)
                {
                    entity.EventTimeStatisticId = await _eventTimeStatisticRepository.AddAsync(entity.EventTimeStatistic);
                }
                return await _repository.AddAsync(entity);
            }
            catch (AddSoccerTeamEventGoalsException ex)
            {
                throw new AddSoccerTeamEventGoalsException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new AddSoccerTeamEventGoalsException(ex.Message, ex);
            }
        }
    }
}
