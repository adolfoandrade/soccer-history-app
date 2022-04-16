using App.Service.ViewModels.Statistic;
using System.Threading.Tasks;

namespace App.Service.Interfaces
{
    public interface IStatisticGoalsService
    {
        Task<int> AddAsync(AddStatisticGoalsVM vm);
    }
}
