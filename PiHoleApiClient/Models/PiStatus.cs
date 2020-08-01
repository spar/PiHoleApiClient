using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiHoleApiClient.Models
{
    public class PiStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
