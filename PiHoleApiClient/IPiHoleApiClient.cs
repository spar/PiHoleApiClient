using PiHoleApiClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PiHoleApiClient
{
    /// <summary>
    /// Pi Hole API client. more information at : https://discourse.pi-hole.net/t/pi-hole-api/1863
    /// </summary>
    public interface IPiHoleApiClient
    {
        Task<ApiVersion> GetApiVersionAsync();

        Task<BackendType> GetApiBackendTypeAsync();

        Task<Summary> GetSummaryRawAsync();

        Task<Summary> GetSummaryAsync();

        Task<OverTimeData10mins> GetOverTimeData10minsAsync();

        Task<TopItems> GetTopItemsAsync();

        Task<TopClients> GetTopClientsAsync();


        Task<ForwardDestinations> GetForwardDestinationsAsync();

        Task<Querytypes> GetQueryTypesAsync();


        Task<List<Query>> GetAllQueriesAsync();

        Task<PiStatus> Enable();

        Task<PiStatus> Disable(long seconds = 0);

        Task<string> RecentlyBlockedAsync();
    }
}