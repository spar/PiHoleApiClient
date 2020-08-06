using Newtonsoft.Json;
using System.Collections.Generic;

namespace PiHoleApiClient.Models
{
    public class Querytypes
    {
        [JsonProperty("querytypes")]
        public Dictionary<string, double> Types { get; set; }
    }
}
