using RoutingWithBikes.ProxyCache;
using System;
using System.Collections.Generic;
using System.Device.Location;
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
        protected List<Station> stations = new List<Station>();
        public RoutingWithBikesImpl()
        {
            this .stations = GetStations(null);
        }
        public RoutingWithBikesImpl(string city)
        {
            this.city = city;
        }

        public string computeRoute(string addressOfStart, string addressOfDest)
        {
            bool isAddOfStart = true;
            
            string parsed_addressOfStart = addressOfStart.Replace(" ", "%20");
            string parsed_addressOfDest = addressOfDest.Replace(" ", "%20");


            string uriOfStart = "https://api.openrouteservice.org/geocode/autocomplete?api_key=5b3ce3597851110001cf62483cf85a66475a41ac904d47754e418791&text=" + parsed_addressOfStart;
            string uriOfDes = "https://api.openrouteservice.org/geocode/autocomplete?api_key=5b3ce3597851110001cf62483cf85a66475a41ac904d47754e418791&text=" + parsed_addressOfDest;

            Task<HttpResponseMessage> resp = ht.GetAsync(uriOfStart);
            
            string responseBody = resp.Result.Content.ReadAsStringAsync().Result.ToString();
            
            OpenRouteServiceObj obj = JsonSerializer.Deserialize<OpenRouteServiceObj>(responseBody);
            
            double latOfStart, lngOfStart, latOfDest, lngOfDest;
            lngOfStart = obj.Features[0].Geometry.Coordinates[0];
            latOfStart = obj.Features[0].Geometry.Coordinates[1];
            System.Diagnostics.Debug.WriteLine("======= lngOfStart = " + lngOfStart);
            System.Diagnostics.Debug.WriteLine("======= latOfStart = " + latOfStart);
            GeoCoordinate geoLocationOfAddressOfStart = new GeoCoordinate(latOfStart, lngOfStart);


            Station closestStationToAddressOfStart =
                computeClosestStationToAddress(geoLocationOfAddressOfStart, stations, isAddOfStart);


            resp = ht.GetAsync(uriOfDes);
            responseBody = resp.Result.Content.ReadAsStringAsync().Result.ToString();
            obj = JsonSerializer.Deserialize<OpenRouteServiceObj>(responseBody);
            
            lngOfDest = obj.Features[0].Geometry.Coordinates[0];
            latOfDest = obj.Features[0].Geometry.Coordinates[1];

            System.Diagnostics.Debug.WriteLine("======= lngOfDest = " + lngOfDest);
            System.Diagnostics.Debug.WriteLine("======= latOfDest = " + latOfDest);

            GeoCoordinate geoLocationOfAddressOfDest = new GeoCoordinate(latOfDest, lngOfDest);

            Station closestStationToAddressOfDest =
                computeClosestStationToAddress(geoLocationOfAddressOfDest, stations,!isAddOfStart);

            if (closestStationToAddressOfDest != null && closestStationToAddressOfStart != null)
            {

                System.Diagnostics.Debug.WriteLine("start = " + closestStationToAddressOfStart.ToString() + " dest = " + closestStationToAddressOfDest.ToString());
                //System.Diagnostics.Debug.WriteLine("stations[0].Position.Lat = " + stations[0].Position.Lat + " stations[0].Position.Lng = " + stations[0].Position.Lng);
                return "start = " + closestStationToAddressOfStart.Name + " dest = " + closestStationToAddressOfDest.Name;

            }
            else return stations.Count.ToString();

        }

        public Station GetInfoOnStation(string city, int id)
        {
            ServiceProxyClient cache = new ServiceProxyClient();

            return JsonSerializer.Deserialize<Station>(cache.getInfoOfStaition(id, city));
        }

        public List<Station> GetStations(string city)
        {
            

            string uri = "https://api.jcdecaux.com/vls/v3/stations?apiKey=c9c6ff3f25cb517f16421e2c4d191fe0a70ebbfe";
            
            Task<HttpResponseMessage> resp = ht.GetAsync(uri);

            string responseBody = resp.Result.Content.ReadAsStringAsync().Result.ToString();

            return JsonSerializer.Deserialize<List<Station>>(responseBody);
            

        }

        private Station computeClosestStationToAddress(GeoCoordinate coordinate,List<Station> stations, bool isAddOfStart)
        {
            if (stations  == null) throw NullReferenceException();
            System.Diagnostics.Debug.WriteLine("coordinate.Latitude = " + coordinate.Latitude);
            System.Diagnostics.Debug.WriteLine("coordinate.Longitude = " + coordinate.Longitude);
            stations.Sort(delegate (Station x, Station y)
            {
                GeoCoordinate coordinateX = new GeoCoordinate(x.Position.Lat, x.Position.Lng);
                GeoCoordinate coordinateY = new GeoCoordinate(y.Position.Lat, y.Position.Lng);
                return coordinateX.GetDistanceTo(coordinate).CompareTo(
                    coordinateY.GetDistanceTo(coordinate)
                    );
            });

            for(int i = 0; i < stations.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(stations[i].ToString());
            }

            if (isAddOfStart)
            {
                for (int i = 0; i < stations.Count; i++)
                {
                    if (stations[i].MainStands.Availabilities.Bikes > 0)
                        return stations[i]; // return the 1st available
                }
            }
            else
            {
                for (int i = 0; i < stations.Count; i++)
                {
                    if (stations[i].MainStands.Availabilities.Stands > 0)
                        return stations[i];

                }
            }
            return null;
        }

        private Exception NullReferenceException()
        {
            throw new NotImplementedException();
        }
    }
}
