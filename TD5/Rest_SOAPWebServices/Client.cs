using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_SOAPWebServices
{
    class Client
    {
        static void Main()
        {
            Service1 client = new Service1();

            client.GetData(10);
            // Utilisez la variable 'client' pour appeler des opérations sur le service.

            // Fermez toujours le client.
            //client.Close();
        }
    }

}
