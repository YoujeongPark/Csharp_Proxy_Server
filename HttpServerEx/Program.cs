using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
namespace HttpServerEx
{
    internal class Program
    {
        public static HttpListener listener;

        static void Main(string[] args)
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.1:8000/");
            listener.Prefixes.Add("http://127.0.0.1:8001/");
            listener.Start();
            Connect().GetAwaiter().GetResult();

        }

        public static async Task Connect()
        {
            bool runServer = true;

            while (runServer)
            {



            }

        }
    }
}
