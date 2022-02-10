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
        private static ProxyCache<JCDecauxObj> cache = null;

        private double FIFTEEN_MINUTES = 900.0;

        private static string KEY = "c9c6ff3f25cb517f16421e2c4d191fe0a70ebbfe";

        public ServiceProxyImpl()
        {
            if (cache == null) cache = new ProxyCache<JCDecauxObj>();
        }

        public string getInfoOfStaition(int id, string city)
        {
            string uri = "https://api.jcdecaux.com/vls/v3/stations/"+id+"?contract="+city+"&apiKey="+KEY;

            return cache.Get(uri, FIFTEEN_MINUTES).getjsonObj(); // saving for 15 mins

        }

    }
}
