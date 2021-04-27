using RoutingWithBikes.ProxyCache;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
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
        protected static List<Station> stations = null;
        private double LIMIT_CONST_DISTANCE = 1500; // 1,5 km. 

        public RoutingWithBikesImpl()
        {
            if(stations == null) stations = GetStations(null);
        }
        public RoutingWithBikesImpl(string city)
        {
            this.city = city;
        }

        public SerialisedObject computeRoute(string addressOfStart, string addressOfDest)
        {
            // CROS origine policy
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");

            bool isAddOfStart = true;
            
            string parsed_addressOfStart = addressOfStart.Replace(" ", "%20");
            string parsed_addressOfDest = addressOfDest.Replace(" ", "%20");


            string uriOfStart = "https://api.openrouteservice.org/geocode/autocomplete?api_key=5b3ce3597851110001cf62483cf85a66475a41ac904d47754e418791&text=" + parsed_addressOfStart;
            string uriOfDes = "https://api.openrouteservice.org/geocode/autocomplete?api_key=5b3ce3597851110001cf62483cf85a66475a41ac904d47754e418791&text=" + parsed_addressOfDest;

            Task<HttpResponseMessage> resp = ht.GetAsync(uriOfStart);
            
            string responseBody = resp.Result.Content.ReadAsStringAsync().Result.ToString();
            
            OpenRouteServiceObjForTxt obj = JsonSerializer.Deserialize<OpenRouteServiceObjForTxt>(responseBody);
            
            double latOfStart, lngOfStart, latOfDest, lngOfDest;    
            lngOfStart = obj.Features[0].Geometry.Coordinates[0];
            latOfStart = obj.Features[0].Geometry.Coordinates[1];

            GeoCoordinate geoLocationOfAddressOfStart = new GeoCoordinate(latOfStart, lngOfStart);

            
            resp = ht.GetAsync(uriOfDes);
            responseBody = resp.Result.Content.ReadAsStringAsync().Result.ToString();
            obj = JsonSerializer.Deserialize<OpenRouteServiceObjForTxt>(responseBody);
            
            lngOfDest = obj.Features[0].Geometry.Coordinates[0];
            latOfDest = obj.Features[0].Geometry.Coordinates[1];

            GeoCoordinate geoLocationOfAddressOfDest = new GeoCoordinate(latOfDest, lngOfDest);

            List<Position> positions = new List<Position>();

            positions.Add(new Position(geoLocationOfAddressOfStart.Latitude, geoLocationOfAddressOfStart.Longitude));
            positions.Add(new Position(geoLocationOfAddressOfDest.Latitude, geoLocationOfAddressOfDest.Longitude));

            List<OpenRouteServiceApiForPath> hole_path = new List<OpenRouteServiceApiForPath>();

            double dist_start_to_end = geoLocationOfAddressOfDest.GetDistanceTo(geoLocationOfAddressOfStart);
            System.Diagnostics.Debug.WriteLine("####dist_start_to_end = "+ dist_start_to_end);
            System.Diagnostics.Debug.WriteLine("####dist_start_to_end = "+ dist_start_to_end);
            if (dist_start_to_end > LIMIT_CONST_DISTANCE)
            {
                Station closestStationToAddressOfStart =
                computeClosestStationToAddress(geoLocationOfAddressOfStart, stations, isAddOfStart);

                Station closestStationToAddressOfDest =
                    computeClosestStationToAddress(geoLocationOfAddressOfDest, stations, !isAddOfStart);
                if (closestStationToAddressOfDest != null && closestStationToAddressOfStart != null)
                {

                    string uri_start_to_station = "https://api.openrouteservice.org/v2/directions/foot-walking?api_key=5b3ce3597851110001cf62483cf85a66475a41ac904d47754e418791&start=" + geoLocationOfAddressOfStart.Longitude.ToString().Replace(",", ".") + "," + geoLocationOfAddressOfStart.Latitude.ToString().Replace(",", ".") + "&end=" + closestStationToAddressOfStart.Position.Lng.ToString().Replace(",", ".") + "," + closestStationToAddressOfStart.Position.Lat.ToString().Replace(",", ".");

                    string uri_station_to_station = "https://api.openrouteservice.org/v2/directions/foot-walking?api_key=5b3ce3597851110001cf62483cf85a66475a41ac904d47754e418791&start=" + closestStationToAddressOfStart.Position.Lng.ToString().Replace(",", ".") + "," + closestStationToAddressOfStart.Position.Lat.ToString().Replace(",", ".") + "&end=" + closestStationToAddressOfDest.Position.Lng.ToString().Replace(",", ".") + "," + closestStationToAddressOfDest.Position.Lat.ToString().Replace(",", ".");

                    string uri_station_to_dest = "https://api.openrouteservice.org/v2/directions/foot-walking?api_key=5b3ce3597851110001cf62483cf85a66475a41ac904d47754e418791&start=" + closestStationToAddressOfDest.Position.Lng.ToString().Replace(",", ".") + "," + closestStationToAddressOfDest.Position.Lat.ToString().Replace(",", ".") + "&end=" + geoLocationOfAddressOfDest.Longitude.ToString().Replace(",", ".") + "," + geoLocationOfAddressOfDest.Latitude.ToString().Replace(",", ".");

                    resp = ht.GetAsync(uri_start_to_station);
                    string responseBody1 = resp.Result.Content.ReadAsStringAsync().Result.ToString();

                    resp = ht.GetAsync(uri_station_to_station);
                    string responseBody2 = resp.Result.Content.ReadAsStringAsync().Result.ToString();

                    resp = ht.GetAsync(uri_station_to_dest);
                    string responseBody3 = resp.Result.Content.ReadAsStringAsync().Result.ToString();


                    
                    positions.Add(closestStationToAddressOfStart.Position);
                    positions.Add(closestStationToAddressOfDest.Position);

                    hole_path.Add(JsonSerializer.Deserialize<OpenRouteServiceApiForPath>(responseBody1));
                    hole_path.Add(JsonSerializer.Deserialize<OpenRouteServiceApiForPath>(responseBody2));
                    hole_path.Add(JsonSerializer.Deserialize<OpenRouteServiceApiForPath>(responseBody3));

                }

            }

            else {

                string start_to_dest = "https://api.openrouteservice.org/v2/directions/foot-walking?api_key=5b3ce3597851110001cf62483cf85a66475a41ac904d47754e418791&start=" + geoLocationOfAddressOfStart.Longitude.ToString().Replace(",", ".") + "," + geoLocationOfAddressOfStart.Latitude.ToString().Replace(",", ".") + "&end=" + geoLocationOfAddressOfDest.Longitude.ToString().Replace(",", ".") + "," + geoLocationOfAddressOfDest.Latitude.ToString().Replace(",", ".");

                resp = ht.GetAsync(start_to_dest);
                responseBody = resp.Result.Content.ReadAsStringAsync().Result.ToString();

                hole_path.Add(JsonSerializer.Deserialize<OpenRouteServiceApiForPath>(responseBody));

            }

            return new SerialisedObject(positions, hole_path);

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
            ServiceProxyClient cache = new ServiceProxyClient();
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

            if (isAddOfStart)
            {
                for (int i = 0; i < stations.Count; i++)
                {
                    string station_info = cache.getInfoOfStaition(stations[i].Number, stations[i].ContractName);
                    Station deserialised_station = JsonSerializer.Deserialize<Station>(station_info);
                    System.Diagnostics.Debug.WriteLine("station_info = " + station_info);
                    if (deserialised_station.TotalStands.Availabilities.Bikes > 0)
                        return stations[i]; // return the 1st available
                }
            }
            else
            {
                for (int i = 0; i < stations.Count; i++)
                {
                    string station_info = cache.getInfoOfStaition(stations[i].Number, stations[i].ContractName);
                    Station deserialised_station = JsonSerializer.Deserialize<Station>(station_info);
                    if (deserialised_station.TotalStands.Availabilities.Stands > 0)
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
