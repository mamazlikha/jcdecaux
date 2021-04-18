using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class Geometry
    {
        [JsonPropertyName("type")]
        [DataMember]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        [DataMember]
        public List<double> Coordinates { get; set; }
    }
}
