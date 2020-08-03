using Newtonsoft.Json;

namespace PiHoleApiClient.Models
{
    public class PiStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}