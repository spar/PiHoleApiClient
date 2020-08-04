using Newtonsoft.Json;
using System.Collections.Generic;

namespace PiHoleApiClient.Models
{
    public class ForwardDestinations
    {
        [JsonProperty("forward_destinations")]
        public Dictionary<string, string> FwdDestinations { get; set; }
    }
}
