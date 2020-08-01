using Newtonsoft.Json;
using PiHoleApiClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PiHoleApiClient
{
    public class PiHoleApiClient : IPiHoleApiClient
    {
        private string _baseUrl;
        private string _token;
        private static HttpClient _httpClient;
        private readonly string _enableEndpoint = "disable";
        public PiHoleApiClient(HttpClient httpClient, string baseUrl, string token = "")
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
            _token = token;
        }

        public async Task<PiStatus> Disable(long seconds)
        {
            var result = await _httpClient.GetAsync($"{_baseUrl}?{_enableEndpoint}={seconds}&auth={_token}");
            var statusString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PiStatus>(statusString);
        }

        public Task<bool> Enable()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAllQueriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetApiBackendAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetApiVersionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetForwardDestinationsAsStringAsync()
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetForwardDestinationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetOverTimeData10minsAsStringync()
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetOverTimeData10minsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetQueryTypesAsStringAsync()
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetQueryTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSummaryAsStringAsync()
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetSummaryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSummaryRawAsStringAsync()
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetSummaryRawAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTopClientsAsStringAsync()
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetTopClientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTopItemsAsStringAsync()
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetTopItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> RecentlyBlockedAsync()
        {
            throw new NotImplementedException();
        }
    }
}
