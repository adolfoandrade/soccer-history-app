using App.Domain.Exceptions.SoccerTeamEventCard;
using App.Domain.Interfaces;
using App.Service.Interfaces;
using App.Service.ViewModels.Statistic;
using System;
using System.Threading.Tasks;

namespace App.Service
{
    public class StatisticCardsService : IStatisticCardsService
    {
        private readonly ISoccerTeamEventCardRepository _repository;
        private readonly IEventTimeStatisticRepository _eventTimeStatisticRepository;

        public StatisticCardsService(ISoccerTeamEventCardRepository repository,
            IEventTimeStatisticRepository eventTimeStatisticRepository)
        {
            _repository = repository;
            _eventTimeStatisticRepository = eventTimeStatisticRepository;
        }

        public async Task<int> AddAsync(AddStatisticCardsVM vm)
        {
            try
            {
                var entity = vm.ToEntity();
                if (entity.EventTimeStatistic.Id <= 0 || entity.EventTimeStatisticId <= 0)
                {
                    entity.EventTimeStatisticId = await _eventTimeStatisticRepository.AddAsync(entity.EventTimeStatistic);
                }
                return await _repository.AddAsync(entity);
            }
            catch (AddSoccerTeamEventCardException ex)
            {
                throw new AddSoccerTeamEventCardException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new AddSoccerTeamEventCardException(ex.Message, ex);
            }
        }
    }
}
