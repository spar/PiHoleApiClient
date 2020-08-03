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
    }
}