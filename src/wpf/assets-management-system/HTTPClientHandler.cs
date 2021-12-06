using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system
{
    class HTTPClientHandler
    {
        public static string GetJsonData()
        {
            using(var client = new HttpClient())
            {
                var endpoint = new Uri("http://localhost:3000/");
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                return json;
            }
        }
    }
}
