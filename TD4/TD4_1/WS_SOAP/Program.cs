using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_SOAP.ServiceReference1;

namespace WS_SOAP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculatorSoapChannel.Equals(1, 1));
            Console.ReadLine();
        }
    }
}
