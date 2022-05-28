using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HttpTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task(HTTP_GET);
            t.Start();
            Console.ReadLine();
            Console.WriteLine("");
        }

        public async Task<string> GetStringAsync(string proxyURL, string url)
        {
            string content = string.Empty;

            try
            {
                ServicePointManager.Expect100Continue = false;

                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                WebProxy proxy = new WebProxy { Address = new Uri(proxyURL) };

                HttpClientHandler clientHandler = new HttpClientHandler()
                {
                    AllowAutoRedirect = true,
                    AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                    Proxy = proxy,
                };

                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

                    client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");

                    HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

                    HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);

                    if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                    {
                        content = await httpResponseMessage.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (HttpRequestException)
            {
                throw;
            }

            return content;
        }



        public async Task<string> EncodePass(string password)
        {

            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }

        static async void HTTP_GET()
        {
            var TARGETURL = "http://localhost:7000/";
            string responseBody;

            HttpClientHandler handler = new HttpClientHandler()
            {
                Proxy = new WebProxy("http://localhost:8888/"),
                UseProxy = true
            };

            Console.WriteLine("GET: + " + TARGETURL);

            // ... Use HttpClient.            
            HttpClient client = new HttpClient(handler);

            var byteArray = Encoding.ASCII.GetBytes("admin:ezmes!@#123");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            HttpResponseMessage response = await client.GetAsync(TARGETURL + "reqestDate/");
            Console.WriteLine(TARGETURL + "reqestDate/");
            HttpContent content = response.Content;

            responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);

            // ... Check Status Code                                
            Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);

            // ... Read the string.
            string result = await content.ReadAsStringAsync();

            // ... Display the result.
            if (result != null &&
            result.Length >= 50)
            {
                Console.WriteLine(result.Substring(0, 50) + "...");
            }
        }
    }
}
