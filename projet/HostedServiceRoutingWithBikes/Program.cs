using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HostedServiceRoutingWithBikes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(RoutingWithBikes.RoutingWithBikesImpl)))
            {

                host.Open();

                Console.WriteLine("The service is ready at {0}", host.BaseAddresses[0]);

                Console.ReadLine();

                // Close the ServiceHost - not really needed because Docker will destroy the host and us with it
                host.Close();
            }
        }
    }
}
