using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system
{
    class HTTPClientHandler
    {
        // 4 cái CRUD : GET, POST, PATCH, DELETE
        public static string GetJsonData(string uri)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri(uri);
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                return json;
            }
        }

        public static string PostJsonData(string uri, object obj)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri(uri);
                var jsonConvertedObject = JsonConvert.SerializeObject(obj);
                var httpcontent = new StringContent(jsonConvertedObject, Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, httpcontent).Result.Content.ReadAsStringAsync().Result;   
                return result;
            }
        }

        public static string PatchJsonData(string uri, object obj)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri(uri);
                var jsonConvertedObject = JsonConvert.SerializeObject(obj);
                var httpcontent = new StringContent(jsonConvertedObject, Encoding.UTF8, "application/json");
                var result = client.PatchAsync(uri, httpcontent).Result.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        public static string DeleteJsonData(string uri)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri(uri);
                var result = client.DeleteAsync(uri).Result.Content.ReadAsStringAsync().Result;
                return result;
            }
        }





    }
}
