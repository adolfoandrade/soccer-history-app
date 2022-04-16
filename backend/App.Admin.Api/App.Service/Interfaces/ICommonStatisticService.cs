using App.Service.ViewModels.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Interfaces
{
    public interface ICommonStatisticService
    {
        Task<int> AddAsync(AddCommonStatisticVM vm);
    }
}
