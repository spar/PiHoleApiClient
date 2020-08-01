using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PiHoleApiClient
{
    public class PiHoleApiClient : IPiHoleApiClient
    {
        private string _baseUl;
        private string _token;
        public PiHoleApiClient(string baseUrl, string token)
        {
            _baseUl = baseUrl;
            _token = token;
        }

        public Task<bool> Disable(long seconds)
        {
            throw new NotImplementedException();
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
