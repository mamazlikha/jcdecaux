using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_MathLib.Operations;

namespace Client_MathLib
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperationsClient mathsOperations = new MathsOperationsClient();

            Console.WriteLine(mathsOperations.Add(5, 6));
            Console.ReadLine();
        }
    }
}
