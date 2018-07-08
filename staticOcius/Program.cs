using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace staticOcius
{
    public class Program
    {
        private readonly HttpClient _httpClient;

        public Program(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public async Task<string> GetHtml(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
