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

        public CommonStatisticService(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(AddCommonStatisticVM vm)
        {
            try
            {
                var entity = vm.ToEntity();
                return await _repository.AddAsync(entity);
            }
            catch (AddStatisticException ex)
            {
                throw new AddStatisticException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new AddStatisticException(ex.Message, ex);
            }
        }

    }
}
