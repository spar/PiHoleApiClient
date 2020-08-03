using Moq;
using Moq.Protected;
using System;
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
        public async void PiHoleEnable_Sucess()
        {
            string successResponse = "{\"status\": \"disabled\"}";
            var httpClient = new HttpClient(GetMockHttpMsgHandler(successResponse).Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var status = await piholeClient.Disable(10);

            Assert.NotNull(status);
            Assert.Equal("disabled", status.Status);
        }
    }
}
