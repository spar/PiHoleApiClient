using Newtonsoft.Json;

namespace PiHoleApiClient.Models
{
    public class Summary
    {
        [JsonProperty("domains_being_blocked")]
        public string DomainsBeingBlocked { get; set; }

        [JsonProperty("dns_queries_today")]
        public string DnsQueriesToday { get; set; }

        [JsonProperty("ads_blocked_today")]
        public string AdsBlockedToday { get; set; }

        [JsonProperty("ads_percentage_today")]
        public string AdsPercentageToday { get; set; }

        [JsonProperty("unique_domains")]
        public string UniqueDomains { get; set; }

        [JsonProperty("queries_forwarded")]
        public string QueriesForwarded { get; set; }

        [JsonProperty("queries_cached")]
        public string QueriesCached { get; set; }

        [JsonProperty("clients_ever_seen")]
        public string ClientsEverSeen { get; set; }

        [JsonProperty("unique_clients")]
        public string UniqueClients { get; set; }

        [JsonProperty("dns_queries_all_types")]
        public string DnsQueriesAllTypes { get; set; }

        [JsonProperty("reply_NODATA")]
        public string ReplyNoData { get; set; }

        [JsonProperty("reply_NXDOMAIN")]
        public string ReplyNxDomain { get; set; }

        [JsonProperty("reply_CNAME")]
        public string ReplyCname { get; set; }

        [JsonProperty("reply_IP")]
        public string ReplyIp { get; set; }

        [JsonProperty("privacy_level")]
        public string PrivacyLevel { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("gravity_last_updated")]
        public GravityLastUpdated GravityLastUpdated { get; set; }


    }
    public class Relative
    {
        [JsonProperty("days")]
        public int Days { get; set; }

        [JsonProperty("hours")]
        public int Hours { get; set; }

        [JsonProperty("minutes")]
        public int Minutes { get; set; }
    }

    public class GravityLastUpdated
    {
        [JsonProperty("file_exists")]
        public bool FileExists { get; set; }

        [JsonProperty("absolute")]
        public string Absolute { get; set; }

        [JsonProperty("relative")]
        public Relative Relative { get; set; }
    }
}
