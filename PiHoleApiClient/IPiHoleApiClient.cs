using System;
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
        Task<string> GetAllQueriesAsync();
        Task<bool> Enable();
        Task<bool> Disable(long seconds);
        Task<string> RecentlyBlockedAsync();
    }
}
