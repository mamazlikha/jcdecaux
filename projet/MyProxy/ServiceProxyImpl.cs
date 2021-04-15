using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyProxy
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class ServiceProxyImpl : IServiceProxy
    {
        public string GetSomething()
        {
            return "toto";
        }


        public string getInfoOfStaition(int id, string city)
        {
            string uri = "https://api.jcdecaux.com/vls/v1/stations/"+id+"?contract="+city+"&apiKey=c9c6ff3f25cb517f16421e2c4d191fe0a70ebbfe";
            ProxyCache<JCDecauxObj> cache = new ProxyCache<JCDecauxObj>();

            return cache.Get(uri, 900.0).getjsonObj(); // 15 saving for mins

        }


    }
}
