using Moq;
using Moq.Protected;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PiHoleApiClient.Tests
{
    public class PiHoleApiClientTests
    {
        private Mock<HttpMessageHandler> GetMockHttpMsgHandler(string response)
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock.Protected()
                   // Setup the PROTECTED method to mock
                   .Setup<Task<HttpResponseMessage>>(
                      "SendAsync",
                      ItExpr.IsAny<HttpRequestMessage>(),
                      ItExpr.IsAny<CancellationToken>()
                   )
                   // prepare the expected response of the mocked http call
                   .ReturnsAsync(new HttpResponseMessage()
                   {
                       StatusCode = HttpStatusCode.OK,
                       Content = new StringContent(response),
                   })
                   .Verifiable();
            return handlerMock;
        }

        [Fact]
        public async void PiHoleDisable_Success()
        {
            string successResponse = "{\"status\": \"disabled\"}";
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var status = await piholeClient.Disable(10);

            Assert.NotNull(status);
            Assert.Equal("disabled", status.Status);
        }

        [Fact]
        public async void PiHoleEnable_Success()
        {
            string successResponse = "{\"status\": \"enabled\"}";
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var status = await piholeClient.Enable();

            Assert.NotNull(status);
            Assert.Equal("enabled", status.Status);
        }

        [Fact]
        public async void GetAllQueries_Success()
        {
            string successResponse = File.ReadAllText("Data/Api/getAllQueries.json");
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var queries = await piholeClient.GetAllQueriesAsync();

            Assert.NotNull(queries);
            Assert.True(queries.Count > 0);
            Assert.Equal("1596348004", queries[0].Time);
            Assert.Equal("AAAA", queries[0].Type);
            Assert.Equal("mytestsite.net", queries[0].Domain);
            Assert.Equal("127.0.0.1", queries[0].Client);
            Assert.Equal("OK (forwarded)", queries[0].Status);
        }

        [Fact]
        public async void GetApiBackendType_Success()
        {
            string successResponse = "{\"type\": \"FTL\"}";
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var typeObj = await piholeClient.GetApiBackendTypeAsync();

            Assert.NotNull(typeObj);
            Assert.Equal("FTL", typeObj.Type);
        }


        [Fact]
        public async void GetApiVersion_Success()
        {
            string successResponse = "{\"version\": 3}";
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "");
            var versionObj = await piholeClient.GetApiVersionAsync();

            Assert.NotNull(versionObj);
            Assert.Equal("3", versionObj.Version);
        }

        [Fact]
        public async void GetForwardDestinationsAsStringc_Success()
        {
            string successResponse = File.ReadAllText("Data/Api/getForwardDestinations.json");
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var fwdsObj = await piholeClient.GetForwardDestinationsAsync();

            Assert.NotNull(fwdsObj);
            Assert.True(fwdsObj.FwdDestinations.Count > 0);
            Assert.Equal("4.22", fwdsObj.FwdDestinations["blocklist|blocklist"]);
            Assert.Equal("61.69", fwdsObj.FwdDestinations["cache|cache"]);
            Assert.Equal("21.7", fwdsObj.FwdDestinations["one.one.one.one|1.1.1.1"]);
            Assert.Equal("18.1", fwdsObj.FwdDestinations["one.one.one.one|1.0.0.1"]);
        }

        [Fact]
        public async void GetOverTimeData10minsAsync_Success()
        {
            string successResponse = File.ReadAllText("Data/Api/overTimeData10mins.json");
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var ovrTimeObj = await piholeClient.GetOverTimeData10minsAsync();

            Assert.NotNull(ovrTimeObj);
            Assert.True(ovrTimeObj.AdsOverTime.Count > 0);
            Assert.True(ovrTimeObj.DomainsOverTime.Count > 0);
            Assert.Equal(66, ovrTimeObj.DomainsOverTime["1596438300"]);
            Assert.Equal(8, ovrTimeObj.AdsOverTime["1596438300"]);
        }

        [Fact]
        public async void GetQueryTypesAsync_Success()
        {
            string successResponse = File.ReadAllText("Data/Api/getQueryTypes.json");
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var qTypeObj = await piholeClient.GetQueryTypesAsync();

            Assert.NotNull(qTypeObj);
            Assert.True(qTypeObj.Types.Count > 0);
            Assert.Equal(73.4, qTypeObj.Types["A (IPv4)"]);
            Assert.Equal(25.27, qTypeObj.Types["AAAA (IPv6)"]);
        }

        [Fact]
        public async void GetSummaryAsync_Success()
        {
            string successResponse = File.ReadAllText("Data/Api/summary.json");
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var summaryObj = await piholeClient.GetSummaryAsync();

            Assert.NotNull(summaryObj);
            Assert.NotNull(summaryObj.GravityLastUpdated);
            Assert.NotNull(summaryObj.GravityLastUpdated.Relative);
            Assert.Equal("85,674", summaryObj.DomainsBeingBlocked);
            Assert.Equal("6,787", summaryObj.DnsQueriesToday);
            Assert.True(summaryObj.GravityLastUpdated.FileExists);
            Assert.Equal("1596340568", summaryObj.GravityLastUpdated.Absolute);
            Assert.Equal(2, summaryObj.GravityLastUpdated.Relative.Days);
        }

        [Fact]
        public async void GetSummaryRawAsync_Success()
        {
            string successResponse = File.ReadAllText("Data/Api/summaryRaw.json");
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var summaryObj = await piholeClient.GetSummaryAsync();

            Assert.NotNull(summaryObj);
            Assert.NotNull(summaryObj.GravityLastUpdated);
            Assert.NotNull(summaryObj.GravityLastUpdated.Relative);
            Assert.Equal("85674", summaryObj.DomainsBeingBlocked);
            Assert.Equal("1700", summaryObj.DnsQueriesToday);
            Assert.True(summaryObj.GravityLastUpdated.FileExists);
            Assert.Equal("1596340568", summaryObj.GravityLastUpdated.Absolute);
            Assert.Equal(2, summaryObj.GravityLastUpdated.Relative.Days);
        }

        [Fact]
        public async void GetTopClientsAsync_Success()
        {
            string successResponse = File.ReadAllText("Data/Api/topClients.json");
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var tClientsObj = await piholeClient.GetTopClientsAsync();

            Assert.NotNull(tClientsObj);
            Assert.Equal(1409, tClientsObj.TopSources["win10.internal.cloudapp.net|10.0.2.4"]);
        }

        [Fact]
        public async void GetTopItemssAsync_Success()
        {
            string successResponse = File.ReadAllText("Data/Api/topItems.json");
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var tItemsObj = await piholeClient.GetTopItemsAsync();

            Assert.NotNull(tItemsObj);
            Assert.Equal(92, tItemsObj.TopQueries["polling.bbc.co.uk"]);
            Assert.Equal(534, tItemsObj.TopAds["g.msn.com"]);
        }

        [Fact]
        public async void GetRecentlyBlocked_Success()
        {
            string successResponse = "vortex.data.microsoft.com";
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var blocked = await piholeClient.RecentlyBlockedAsync();

            Assert.NotNull(blocked);
            Assert.Equal("vortex.data.microsoft.com", blocked);
        }


    }
}