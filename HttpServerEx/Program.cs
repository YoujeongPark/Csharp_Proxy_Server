using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;

namespace HttpServerEx
{
    internal class Program
    {
        public static HttpListener listener;

        static void Main(string[] args)
        {


            //listener = new HttpListener();
            //listener.Prefixes.Add("http://127.0.0.1:8000/");
            //listener.Prefixes.Add("http://127.0.0.1:8001/");
            //listener.Start();
            //Connect().GetAwaiter().GetResult();
            int number = 7; 
            Thread thread1 = new Thread(() => Sum(number, 2, 3));
            thread1.Start();

            Thread thread2 = new Thread(() => Sum(number, 7, 8));
            thread2.Start();
        }


        static void Sum(int d1, int d2, int d3)
        {
            int sum = d1 + d2 + d3;
            while (true)
            {
                Console.WriteLine(sum);
                Thread.Sleep(2000);
            }
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
