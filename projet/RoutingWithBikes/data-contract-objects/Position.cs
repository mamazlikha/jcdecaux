using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    [DataContract]
    public class Position
    {

        public Position(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        [JsonPropertyName("latitude")]
        [DataMember]
        public double Lat { get; set; }

        [JsonPropertyName("longitude")]
        [DataMember]
        public double Lng { get; set; }

        public override string ToString()
        {
            return "{\"Lat\":"+Lat.ToString().Replace(",",".")+",\"Lng\":"+Lng.ToString().Replace(",", ".") + "}";
        }
    }
}
