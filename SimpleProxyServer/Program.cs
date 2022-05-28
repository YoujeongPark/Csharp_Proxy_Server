using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProxyServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WebProxy proxyObject = new WebProxy("http://127.0.0.1:80/", true);
                WebRequest req = WebRequest.Create("http://www.contoso.com");
                req.Proxy = proxyObject;

            }
            
        }
    }
}
