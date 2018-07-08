using System;
using Xunit;
using staticOcius;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using Moq;
using System.Net;
using System.Collections.Generic;

namespace staticOciusTests
{
    public class ProgramTests
    {
        [Fact]
        public async Task GetHtml_WhenValidUrl_ReturnsHtml()
        {
            //Arrange
            var fakeHttpMessageHandler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(fakeHttpMessageHandler);
            var program = new Program(httpClient);
            var url = "https://example.com";
            var expected = "<p>hello world</p>";

            //Act
            var actual = await program.GetHtml(url);

            //Assert
            Assert.Equal(expected, actual);
        }
    }

    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return new HttpResponseMessage(HttpStatusCode.NotFound) 
            { 
                RequestMessage = request,
                Content = new StringContent("<p>hello world</p>")
            };
        }
    }
}
