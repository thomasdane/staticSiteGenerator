using System;
using Xunit;
using staticOcius;
using System.Threading.Tasks;
using System.Net.Http;

namespace staticOciusTests
{
    public class ProgramTests
    {
        private HttpClient _httpClient;

        public ProgramTests()
        {
            _httpClient = new HttpClient();
        }

        [Fact]
        public async Task GetHtml_WhenValidUrl_ReturnsHtml()
        {
            //Arrange

            var program = new Program(_httpClient);
            var url = "https://example.com";
            var expected = "<p>hello world</p>";

            //Act
            var actual = await program.GetHtml(url);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
