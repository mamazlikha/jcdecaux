using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace BasicClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProxy.ServiceProxyClient proxy = new ServiceProxy.ServiceProxyClient();
            Console.WriteLine("Hello\n");
            Console.WriteLine(proxy.GetContacts());
            Console.ReadLine();
        }
    }
}
