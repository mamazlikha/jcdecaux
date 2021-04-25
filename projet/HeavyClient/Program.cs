using HeavyClient.RoutingWithBikesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RoutingWithBikesClient bikes = new RoutingWithBikesClient();
            string address_of_start, address_of_dest;
            Console.WriteLine("Address of start : ");
            address_of_start = Console.ReadLine();

            Console.WriteLine("Address of destination : ");
            address_of_dest = Console.ReadLine();

            SerialisedObject serialisedObject = bikes.computeRoute(address_of_start, address_of_dest);

            FeatureForPath[] path1 = serialisedObject.AllPath[0].Features;

            FeatureForPath[] path2 = null;

            FeatureForPath[] path3 = null;

            if (serialisedObject.AllPath.Length >1)
            {
                path2 = serialisedObject.AllPath[1].Features;

                path3 = serialisedObject.AllPath[2].Features;

            }

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            if (path2 != null && path3 != null)
            {
                Console.WriteLine("=========on your feet :");
                Step[] steps = path1[0].properties.Segments[0].Steps;
                for (int i = 0; i < steps.Length; i++)
                {
                    Console.WriteLine(steps[i].Instruction);
                }
                Console.WriteLine("\n");
                Console.WriteLine("=========on the bike :");
                steps = path2[0].properties.Segments[0].Steps;
                for (int i = 0; i < steps.Length; i++)
                {
                    Console.WriteLine(steps[i].Instruction);
                }
                Console.WriteLine("\n");
                Console.WriteLine("=========on your feet :");
                steps = path3[0].properties.Segments[0].Steps;
                for (int i = 0; i < steps.Length; i++)
                {
                    Console.WriteLine(steps[i].Instruction);
                }
            }

            else
            {
                Console.WriteLine("=========on your feet :");
                Step[] steps = path1[0].properties.Segments[0].Steps;
                for (int i = 0; i < steps.Length; i++)
                {
                    Console.WriteLine(steps[i].Instruction);
                }
                Console.WriteLine("\n");

            }
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("=========== Goodbye !! ==========");
            Console.ReadLine();
        }
    }
}
