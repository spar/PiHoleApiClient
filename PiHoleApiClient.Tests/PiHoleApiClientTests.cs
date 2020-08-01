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
        [Fact]
        public async void PiHoleEnable_Sucess()
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
                       Content = new StringContent("{\"status\": \"disabled\"}"),
                   })
                   .Verifiable();
            var httpClient = new HttpClient(handlerMock.Object);

            var piholeClient = new PiHoleApiClient(httpClient, "http://pi.hole/admin/api.php", "token");
            var status = await piholeClient.Disable(10);

            Assert.NotNull(status);
            Assert.Equal("disabled", status.Status);



        }
    }
}
