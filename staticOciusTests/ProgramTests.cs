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
            var fakeResponseHandler = new FakeHttpMessageHandler();
            fakeResponseHandler.AddFakeResponse(new Uri("http://example.org/test"), new HttpResponseMessage(HttpStatusCode.OK));

            var httpClient = new HttpClient(fakeResponseHandler);

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
        private readonly Dictionary<Uri, HttpResponseMessage> _FakeResponses = new Dictionary<Uri, HttpResponseMessage>(); 

        public void AddFakeResponse(Uri uri, HttpResponseMessage responseMessage)
        {
                _FakeResponses.Add(uri,responseMessage);
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (_FakeResponses.ContainsKey(request.RequestUri))
            {
                return _FakeResponses[request.RequestUri];
            }
            else
            {
                var foo = new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request};
                var content = new StringContent("<p>hello world</p>");
                foo.Content = content;
                return foo;
            }
        }
    }
}
