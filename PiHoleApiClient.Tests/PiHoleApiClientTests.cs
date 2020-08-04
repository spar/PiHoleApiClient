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


    }
}