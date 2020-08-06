[![Build Status](https://dev.azure.com/sandeepparekh/PiHoleApiClient/_apis/build/status/PiHoleApiClient-CI?branchName=master)](https://dev.azure.com/sandeepparekh/PiHoleApiClient/_build/latest?definitionId=11&branchName=master)
# Introduction
This is a cross platform client for communicating with [Pi-Hole](https://pi-hole.net/) API, a network wide Ads blocking DNS Sink.

## Pi-Hole Endpoints
Available endpoints

### **version**
This endpoint return Pi-hole API's version.

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var versionObj = await apiClient.GetApiVersionAsync();
Console.WriteLine(versionObj.Version);
//3
```


### **type**
Return Pi-hole API's backend Type

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var typeObj = await apiClient.GetApiBackendTypeAsync();
Console.WriteLine(typeObj.Type);
//FTL
```

### **summaryRaw**
Returns Statistics in Raw format  

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var summaryRaw = await apiClient.GetSummaryRawAsync();
Console.WriteLine(JsonConvert.SerializeObject(summaryRaw));
```
Output
```json
{
    "domains_being_blocked": 85674,
    "dns_queries_today": 1700,
    "ads_blocked_today": 304,
    "ads_percentage_today": 17.882353,
    "unique_domains": 2407,
    "queries_forwarded": 981,
    "queries_cached": 403,
    "clients_ever_seen": 4,
    "unique_clients": 1,
    "dns_queries_all_types": 1700,
    "reply_NODATA": 355,
    "reply_NXDOMAIN": 105,
    "reply_CNAME": 1173,
    "reply_IP": 924,
    "privacy_level": 0,
    "status": "enabled",
    "gravity_last_updated": {
        "file_exists": true,
        "absolute": 1596340568,
        "relative": {
            "days": 2,
            "hours": 21,
            "minutes": 20
        }
    }
}
```

### **summary**
Returns Statistics formatted style

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var summary = await apiClient.GetSummaryAsync();
Console.WriteLine(JsonConvert.SerializeObject(summary));
```
Output
```json
{
    "domains_being_blocked": "85,674",
    "dns_queries_today": "6,787",
    "ads_blocked_today": "326",
    "ads_percentage_today": "4.8",
    "unique_domains": "2,262",
    "queries_forwarded": "2,379",
    "queries_cached": "4,064",
    "clients_ever_seen": "4",
    "unique_clients": "3",
    "dns_queries_all_types": "6,787",
    "reply_NODATA": "1,827",
    "reply_NXDOMAIN": "1,464",
    "reply_CNAME": "1,432",
    "reply_IP": "2,669",
    "privacy_level": "0",
    "status": "enabled",
    "gravity_last_updated": {
        "file_exists": true,
        "absolute": 1596340568,
        "relative": {
            "days": 2,
            "hours": 2,
            "minutes": 48
        }
    }
}
```

### **overTimeData10mins**
Returns domains and ads data over 10 min. Useful for showing graphs

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var data = await apiClient.GetOverTimeData10minsAsync();
Console.WriteLine(JsonConvert.SerializeObject(data));
```
Output
```json
{
    "domains_over_time": {
        "1596438300": 66,
        "1596438900": 64,
        "1596439500": 69,
        ...
        "1596521100": 13
    },
    "ads_over_time": {
        "1596438300": 8,
        "1596438900": 0,
        ...
        "1596521100": 0
    }
}
```

### **topItems**
Returns tops domains and top ads data

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var data = await apiClient.GetTopItemsAsync();
Console.WriteLine(JsonConvert.SerializeObject(data));
```
Output
```json
{
    "top_queries": {
        "polling.bbc.co.uk": 92,
        "wpad.reddog.microsoft.com": 80,
        "www.bing.com": 60,
        "www.msftncsi.com": 31,
    },
    "top_ads": {
        "g.msn.com": 534,
        "g.live.com": 64,
        "vortex.data.microsoft.com": 20,
        "c.msn.com": 16,
        "watson.telemetry.microsoft.com": 8,
        "web.vortex.data.microsoft.com": 4,
        "otf.msn.com": 2,
        "www.googletagservices.com": 2,
        "mybbc-analytics.files.bbci.co.uk": 2
    }
}
```

### **topClients**
Returns tops clients list

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var data = await apiClient.GetTopClientsAsync();
Console.WriteLine(JsonConvert.SerializeObject(data));
```
Output
```json
{
    "top_sources": {
        "win10|10.0.1.1": 1409
    }
}
```

### **getForwardDestinations**
Shows number of queries that have been forwarded and the target

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var data = await apiClient.GetForwardDestinationsAsync();
Console.WriteLine(JsonConvert.SerializeObject(data));
```
Output
```json
{
    "forward_destinations": {
        "blocklist|blocklist": 4.22,
        "cache|cache": 61.69,
        "one.one.one.one|1.1.1.1": 21.7,
        "one.one.one.one|1.0.0.1": 18.1
    }
}
```

### **getQueryTypes**
Get queries types processed by pi-hole

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var data = await apiClient.GetQueryTypesAsync();
Console.WriteLine(JsonConvert.SerializeObject(data));
```
Output
```json
{
    "querytypes": {
        "A (IPv4)": 73.4,
        "AAAA (IPv6)": 25.27,
        "ANY": 0,
        "SRV": 0.49,
        "SOA": 0,
        "PTR": 0.83,
        "TXT": 0,
        "NAPTR": 0
    }
}
```

### **getAllQueries**
returns all DNS queries

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var data = await apiClient.GetAllQueriesAsync();
Console.WriteLine(JsonConvert.SerializeObject(data));
```
Output
```json
{
    "data": [
        [
            "1596348004",
            "AAAA",
            "mytestsite.net",
            "127.0.0.1",
            "2",
            "0",
            "4",
            "26",
            "N/A",
            "-1"
        ],
        ...
        [
            "1596348004",
            "A",
            "mytestsite.net",
            "127.0.0.1",
            "3",
            "0",
            "1",
            "1",
            "N/A",
            "-1"
        ]
    ]
}
```
### **enable**
enables pi-hole

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var data = await apiClient.Enable();
Console.WriteLine(JsonConvert.SerializeObject(data.Status));
//enabled
```

### **disable**
disables pi-hole

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var data = await apiClient.Disable(10); // disables for 10 seconds, leave empty indefinitely disable it 
Console.WriteLine(JsonConvert.SerializeObject(data.Status));
//diabled
```


### **recentBlocked**
returns most recently blocked domain

```csharp
var httpClient = new HttpClient();
var apiClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
var domain = await apiClient.RecentlyBlockedAsync();
Console.WriteLine(JsonConvert.SerializeObject(domain));
//someAdDomain.com
```

