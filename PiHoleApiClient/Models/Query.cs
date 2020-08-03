using System.Collections.Generic;

namespace PiHoleApiClient.Models
{
    public class PreQuery
    {
        public List<List<string>> Data { get; set; }
    }
    public class Query
    {
        public Query(string time, string type, string domain, string client, string status)
        {
            Time = time;
            Type = type;
            Domain = domain;
            Client = client;
            switch (status)
            {
                case "1":
                    Status = "Blocked (gravity)";
                    break;
                case "2":
                    Status = "OK (forwarded)";
                    break;
                case "3":
                    Status = "OK (cached)";
                    break;
                case "4":
                    Status = "Blocked (regex blacklist)";
                    break;
                case "5":
                    Status = "Blocked (exact blacklist)";
                    break;
                case "6":
                    Status = "Blocked (external, IP)";
                    break;
                case "7":
                    Status = "Blocked (external, NULL)";
                    break;
                case "8":
                    Status = "Blocked (external, NXRA)";
                    break;
                case "9":
                    Status = "Blocked (gravity, CNAME)";
                    break;
                case "10":
                    Status = "Blocked (regex blacklist, CNAME)";
                    break;
                case "11":
                    Status = "Blocked (exact blacklist, CNAME)";
                    break;
                default:
                    Status = "Unknown";
                    break;
            }

        }
        public string Time { get; private set; }
        public string Type { get; private set; }
        public string Domain { get; private set; }
        public string Client { get; private set; }
        public string Status { get; private set; }
    }
}
