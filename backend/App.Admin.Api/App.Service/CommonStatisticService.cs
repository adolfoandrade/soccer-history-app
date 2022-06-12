using App.Domain.Exceptions.Statistic;
using App.Domain.Interfaces;
using App.Service.Interfaces;
using App.Service.ViewModels.Statistic;
using System;
using System.Threading.Tasks;

namespace App.Service
{
    public class CommonStatisticService : ICommonStatisticService
    {
        private readonly IStatisticRepository _repository;
        private readonly IEventTimeStatisticRepository _eventTimeStatisticRepository;

        public CommonStatisticService(IStatisticRepository repository,
            IEventTimeStatisticRepository eventTimeStatisticRepository)
        {
            _repository = repository;
            _eventTimeStatisticRepository = eventTimeStatisticRepository;
        }

        public Task<int> AddAsync(AddCommonStatisticVM vm)
        {
            //try
            //{
            //    var entity = vm.ToEntity();
            //    var eventTime = await _eventTimeStatisticRepository.GetAsync(vm.EventId, (int)entity.EventTimeStatistic.Half, vm.SoccerTeamId);
            //    if (eventTime is null)
            //    {
            //        entity.EventTimeStatisticId = await _eventTimeStatisticRepository.AddAsync(entity.EventTimeStatistic);
            //    }
            //    else
            //    {
            //        entity.EventTimeStatisticId = eventTime.Id;
            //    }
            //    return await _repository.AddAsync(entity);
            //}
            //catch (AddStatisticException ex)
            //{
            //    throw new AddStatisticException(ex.Message, ex);
            //}
            //catch (Exception ex)
            //{
            //    throw new AddStatisticException(ex.Message, ex);
            //}
            return Task.FromResult(1);
        }

    }
}
