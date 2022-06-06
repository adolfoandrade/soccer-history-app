using System.Threading.Tasks;

namespace SyncSoccerData.Clients
{
    public interface IApiFootballBaseClient
    {
        Task<T> GetAsync<T>(string url);
    }
}
