using App.Service.ViewModels.Statistic;
using System.Threading.Tasks;

namespace App.Service.Interfaces
{
    public interface ICommonStatisticService
    {
        Task<int> AddAsync(AddCommonStatisticVM vm);
    }
}
