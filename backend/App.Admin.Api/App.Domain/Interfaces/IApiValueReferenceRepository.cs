using App.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IApiValueReferenceRepository
    {
        Task<ApiValueReference> GetByApiIdAsync(string table, int apiId);
        Task<ApiValueReference> GetByAppIdAsync(string table, int appId);
        Task<IEnumerable<ApiValueReference>> GetByTableNameAsync(string table);
        Task<int> AddAsync(ApiValueReference reference);
        Task<int> UpdateAsync(ApiValueReference reference);
    }
}
