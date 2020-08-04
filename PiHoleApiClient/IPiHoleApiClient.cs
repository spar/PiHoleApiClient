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
        Task<PiApiVersion> GetApiVersionAsync();

        Task<PiApiBackendType> GetApiBackendTypeAsync();

        Task<dynamic> GetSummaryRawAsync();

        Task<Summary> GetSummaryAsync();

        Task<OverTimeData10mins> GetOverTimeData10minsAsync();

        Task<dynamic> GetTopItemsAsync();

        Task<string> GetTopItemsAsStringAsync();

        Task<dynamic> GetTopClientsAsync();

        Task<string> GetTopClientsAsStringAsync();

        Task<ForwardDestinations> GetForwardDestinationsAsync();

        Task<PiQuerytypes> GetQueryTypesAsync();


        Task<List<Query>> GetAllQueriesAsync();

        Task<PiStatus> Enable();

        Task<PiStatus> Disable(long seconds = 0);

        Task<string> RecentlyBlockedAsync();
    }
}