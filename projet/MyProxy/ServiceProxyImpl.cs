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
        static ProxyCache<JCDecauxObj> cache = null;

        public ServiceProxyImpl()
        {
            if (cache == null) cache = new ProxyCache<JCDecauxObj>();
        }

        public string GetSomething()
        {
            return "toto";
        }

        public string getInfoOfStaition(int id, string city)
        {
            string uri = "https://api.jcdecaux.com/vls/v3/stations/"+id+"?contract="+city+"&apiKey=c9c6ff3f25cb517f16421e2c4d191fe0a70ebbfe";

            return cache.Get(uri, 900.0).getjsonObj(); // saving for 15 mins

        }

    }
}
