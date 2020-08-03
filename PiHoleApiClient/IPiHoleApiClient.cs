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
        Task<string> GetApiVersionAsync();

        Task<string> GetApiBackendAsync();

        Task<dynamic> GetSummaryRawAsync();

        Task<string> GetSummaryRawAsStringAsync();

        Task<dynamic> GetSummaryAsync();

        Task<string> GetSummaryAsStringAsync();

        Task<dynamic> GetOverTimeData10minsAsync();

        Task<string> GetOverTimeData10minsAsStringync();

        Task<dynamic> GetTopItemsAsync();

        Task<string> GetTopItemsAsStringAsync();

        Task<dynamic> GetTopClientsAsync();

        Task<string> GetTopClientsAsStringAsync();

        Task<dynamic> GetForwardDestinationsAsync();

        Task<string> GetForwardDestinationsAsStringAsync();

        Task<dynamic> GetQueryTypesAsync();

        Task<string> GetQueryTypesAsStringAsync();

        Task<List<Query>> GetAllQueriesAsync();

        Task<PiStatus> Enable();

        Task<PiStatus> Disable(long seconds = 0);

        Task<string> RecentlyBlockedAsync();
    }
}