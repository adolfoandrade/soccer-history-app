using App.Service.ViewModels.Statistic;
using System.Threading.Tasks;

namespace App.Service.Interfaces
{
    public interface IStatisticCardsService
    {
        Task<int> AddAsync(AddStatisticCardsVM vm);
    }
}
