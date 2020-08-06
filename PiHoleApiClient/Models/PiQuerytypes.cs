using Newtonsoft.Json;
using System.Collections.Generic;

namespace PiHoleApiClient.Models
{
    public class PiQuerytypes
    {
        [JsonProperty("querytypes")]
        public Dictionary<string, double> Querytypes { get; set; }
    }
}
