using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class Feature
    {
        [JsonPropertyName("type")]
        [DataMember]
        public string Type { get; set; }

        [JsonPropertyName("geometry")]
        [DataMember]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("properties")]
        [DataMember]
        public Properties Properties { get; set; }
    }
}
