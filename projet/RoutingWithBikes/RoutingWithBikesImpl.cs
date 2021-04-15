using RoutingWithBikes.ProxyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class RoutingWithBikesImpl : IRoutingWithBikes
    {
        protected string city;

        protected HttpClient ht = new HttpClient();

        public RoutingWithBikesImpl()
        {

        }
        public RoutingWithBikesImpl(string city)
        {
            this.city = city;
        }

        public Station GetInfoOnStation(string city, int id)
        {
            ServiceProxyClient cache = new ServiceProxyClient();

            return JsonSerializer.Deserialize<Station>(cache.getInfoOfStaition(id, city));
        }

        public string GetStations(string city)
        {
            if (city == null) this.city = city;

            string uri = "https://api.jcdecaux.com/vls/v1/stations?contract=" +this.city+ "&apiKey=c9c6ff3f25cb517f16421e2c4d191fe0a70ebbfe";
            Task<HttpResponseMessage> resp = ht.GetAsync(uri);
            string responseBody = resp.Result.Content.ReadAsStringAsync().Result.ToString();

            return uri;//JsonSerializer.Deserialize<List<Station>>(responseBody);

        }

    }
}
