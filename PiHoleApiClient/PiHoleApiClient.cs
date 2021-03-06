﻿using Newtonsoft.Json;
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
        private readonly string _baseUrl;
        private readonly string _token;
        private HttpClient _httpClient;
        private readonly string _disableEndpoint = "disable";
        private readonly string _enabledEndpoint = "enable";
        private readonly string _getAllQueriesEndpoint = "getAllQueries";
        private readonly string _getApiBackendTypeEndpoint = "type";
        private readonly string _getApiVersionEndpoint = "version";
        private readonly string _getForwardDestinationsEndpoint = "getForwardDestinations";
        private readonly string _overTimeData10minsEndpoint = "overTimeData10mins";
        private readonly string _getQueryTypesEndpoint = "getQueryTypes";
        private readonly string _summaryEndpoint = "summary";
        private readonly string _summaryRawEndpoint = "summaryRaw";
        private readonly string _topClientsEndpoint = "topClients";
        private readonly string _topItemsEndpoint = "topItems";
        private readonly string _recentBlockedEndpoint = "recentBlocked";

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

        public async Task<BackendType> GetApiBackendTypeAsync()
        {
            var resultString = await GetResultAsString($"{_baseUrl}?{_getApiBackendTypeEndpoint}");
            return JsonConvert.DeserializeObject<BackendType>(resultString);
        }

        public async Task<ApiVersion> GetApiVersionAsync()
        {
            var resultString = await GetResultAsString($"{_baseUrl}?{_getApiVersionEndpoint}");
            return JsonConvert.DeserializeObject<ApiVersion>(resultString);
        }

        public async Task<ForwardDestinations> GetForwardDestinationsAsync()
        {
            var resultString = await GetResultAsString($"{_baseUrl}?{_getForwardDestinationsEndpoint}&auth={_token}");
            return JsonConvert.DeserializeObject<ForwardDestinations>(resultString);
        }

        public async Task<OverTimeData10mins> GetOverTimeData10minsAsync()
        {
            var resultString = await GetResultAsString($"{_baseUrl}?{_overTimeData10minsEndpoint}");
            return JsonConvert.DeserializeObject<OverTimeData10mins>(resultString);
        }

        public async Task<Querytypes> GetQueryTypesAsync()
        {
            var resultString = await GetResultAsString($"{_baseUrl}?{_getQueryTypesEndpoint}&auth={_token}");
            return JsonConvert.DeserializeObject<Querytypes>(resultString);
        }

        public async Task<Summary> GetSummaryAsync()
        {
            var resultString = await GetResultAsString($"{_baseUrl}?{_summaryEndpoint}");
            return JsonConvert.DeserializeObject<Summary>(resultString);
        }

        public async Task<Summary> GetSummaryRawAsync()
        {
            var resultString = await GetResultAsString($"{_baseUrl}?{_summaryRawEndpoint}");
            return JsonConvert.DeserializeObject<Summary>(resultString);
        }

        public async Task<TopClients> GetTopClientsAsync()
        {
            var resultString = await GetResultAsString($"{_baseUrl}?{_topClientsEndpoint}&auth={_token}");
            return JsonConvert.DeserializeObject<TopClients>(resultString);
        }

        public async Task<TopItems> GetTopItemsAsync()
        {
            var resultString = await GetResultAsString($"{_baseUrl}?{_topItemsEndpoint}&auth={_token}");
            return JsonConvert.DeserializeObject<TopItems>(resultString);
        }

        public async Task<string> RecentlyBlockedAsync()
        {
            return await GetResultAsString($"{_baseUrl}?{_recentBlockedEndpoint}&auth={_token}");
            
        }
    }
}