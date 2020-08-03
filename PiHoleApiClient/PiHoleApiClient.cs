using Newtonsoft.Json;
using PiHoleApiClient.Mappers;
using PiHoleApiClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PiHoleApiClient
{
    public class PiHoleApiClient : IPiHoleApiClient
    {
        private string _baseUrl;
        private string _token;
        private static HttpClient _httpClient;
        private readonly string _disableEndpoint = "disable";
        private readonly string _enabledEndpoint = "enable";
        private readonly string _getAllQueriesEndpoint = "getAllQueries";

        public PiHoleApiClient(HttpClient httpClient, string baseUrl, string token = "")
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
            _token = token;
        }

        private async Task<string> GetResultAsString(string url)
        {
            var r = await _httpClient.GetAsync(url);
            return await r.Content.ReadAsStringAsync();
        }

        public async Task<PiStatus> Disable(long seconds = 0)
        {
            var s = seconds > 0 ? $"{_disableEndpoint}={seconds}" : _disableEndpoint;
            var resultString = await GetResultAsString($"{_baseUrl}?{s}&auth={_token}");
            return JsonConvert.DeserializeObject<PiStatus>(resultString);
        }

        public async Task<PiStatus> Enable()
        {
            return JsonConvert.DeserializeObject<PiStatus>
                (await GetResultAsString($"{_baseUrl}?{_enabledEndpoint}&auth={_token}"));
        }

        public async Task<List<Query>> GetAllQueriesAsync()
        {
            var result = await GetResultAsString($"{_baseUrl}?{_getAllQueriesEndpoint}&auth={_token}");
            return JsonConvert.DeserializeObject<PreQuery>(result).MapQueries();
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