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
        public string GetContacts()
        {
            Console.WriteLine("calling getContacts");
            string uri = "https://api.jcdecaux.com/vls/v1/stations?contract=valence&apiKey=c9c6ff3f25cb517f16421e2c4d191fe0a70ebbfe";
            ProxyCache<JCDecauxObj> cache = new ProxyCache<JCDecauxObj>();
            Console.WriteLine(cache.Get(uri));
            return cache.Get(uri).getjsonObj();

        }
    }
}
