using Newtonsoft.Json;
using System.Collections.Generic;

namespace PiHoleApiClient.Models
{
    public class TopItems
    {
        [JsonProperty("top_queries")]
        public Dictionary<string, long> TopQueries { get; set; }

        [JsonProperty("top_ads")]
        public Dictionary<string, long> TopAds { get; set; }
    }
}
