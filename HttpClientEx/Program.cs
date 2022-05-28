using System;
using System.Collections;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HttpClientEx
{
    internal class Program
    {
        static readonly HttpClient _httpClient = new HttpClient();
        static HttpResponseMessage response;
        static string _baseUrl = "https://localhost:8000/";
        public static int requestCount = 0;

        static void Main(string[] args)
        {

            Connect(_baseUrl).GetAwaiter().GetResult(); // Asyncrhonous Function  
        }

        static async Task Connect(string url)
        {
            bool runClient = true;

            while (runClient)
            {

                JObject jobject = new JObject();
                jobject.Add("Result", "Good");
                var stringPayload = JsonConvert.SerializeObject(jobject);
                var jsonHttpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                response = await _httpClient.PostAsync("http://localhost:8001/" + "PostName", jsonHttpContent);
                response.EnsureSuccessStatusCode();



            }


        }
    }
}
