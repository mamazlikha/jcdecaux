using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class FeatureForPath
    {
        
        [JsonPropertyName("type")]
        [DataMember]
        public string type { get; set; }

        [JsonPropertyName("properties")]
        [DataMember]
        public PropertiesForPath properties { get; set; }

        [JsonPropertyName("geometry")]
        [DataMember]
        public GeometryForPath geometry { get; set; }
    }

}
