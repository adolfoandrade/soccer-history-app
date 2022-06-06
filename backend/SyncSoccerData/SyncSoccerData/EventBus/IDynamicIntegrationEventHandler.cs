using System.Threading.Tasks;

namespace SyncSoccerData.EventBus
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}
