using Newtonsoft.Json;
using System.Collections.Generic;

namespace PiHoleApiClient.Models
{
    public class TopClients
    {
        [JsonProperty("top_sources")]
        public Dictionary<string, long> TopSources { get; set; }
    }
}
