using BasicClient.RoutingWithBikes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace BasicClient
{
    class Program
    {

        

        static void Main(string[] args)
        {
            RoutingWithBikesClient bikes = new RoutingWithBikesClient("valence");
            Station[] stations = bikes.GetStations();
            Console.WriteLine(printStations(stations));
            Console.ReadLine();
        }


        private static string printStations(Station[] stations)
        {
            string toREt = "[";
            int i;
            for (i = 0; i < stations.Length-1; i++)
            {
                toREt += toString(stations[i]);
                toREt += ",";
            }

            toREt += toString(stations[i]);
            return toREt+="]";
        }


        private static string toString(Station station)
        {
            if (station.LastUpdate != null)
            {
                return "{\"Address\":\"" + station.Address + "\",\"AvailableBikeStands\":" + station.AvailableBikeStands +
                    ",\"AvailableBikes\":" + station.AvailableBikes + ",\"Banking\":" + station.Banking +
                    ",\"BikeStands\":" + station.BikeStands + ",\"Bonus\":" + station.Bonus + ",\"ContractName\":\"" + station.ContractName +
                    "\",\"LastUpdate\":" + station.LastUpdate + ",\"Name\":\"" + station.Name + "\",\"Number\":" + station.Number +
                    ",\"Position\":" + "{\"Lat\":" + station.Position.Lat.ToString() + ",\"Lng\":" + station.Position.Lng.ToString() + "}" + ",\"Status\":\"" + station.Status + "\"}";
            }
            else
            {
                return "{\"Address\":\"" + station.Address + "\",\"AvailableBikeStands\":" + station.AvailableBikeStands +
                    ",\"AvailableBikes\":" + station.AvailableBikes + ",\"Banking\":" + station.Banking +
                    ",\"BikeStands\":" + station.BikeStands + ",\"Bonus\":" + station.Bonus + ",\"ContractName\":\"" + station.ContractName +
                   ",\"Name\":\"" + station.Name + "\",\"Number\":" + station.Number +
                    ",\"Position\":" + "{\"Lat\":" + station.Position.Lat.ToString() + ",\"Lng\":" + station.Position.Lng.ToString() + "}" + ",\"Status\":\"" + station.Status + "\"}";
            }
        }

    }
}
