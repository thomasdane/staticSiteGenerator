using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

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
            var serviceCollection = new ServiceCollection().AddSingleton<HttpClient>();          
            Console.WriteLine("Hello World!");
        }

        public async Task<string> GetHtml(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
