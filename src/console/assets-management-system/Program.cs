using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace assets_management_system
{
    class Program
    {   
        private static readonly HttpClient client = new HttpClient();

       
        static async Task Main(string[] args)
        {
             await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("http://localhost:3000/");

            var msg = await stringTask;
            Console.Write(msg);
        }
    }
}
