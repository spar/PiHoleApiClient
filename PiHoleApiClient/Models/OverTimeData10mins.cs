using Newtonsoft.Json;
using System.Collections.Generic;

namespace PiHoleApiClient.Models
{
    public class OverTimeData10mins
    {
        [JsonProperty("domains_over_time")]
        public Dictionary<string, int> DomainsOverTime { get; set; }

        [JsonProperty("ads_over_time")]
        public Dictionary<string, int> AdsOverTime { get; set; }
    }
}
