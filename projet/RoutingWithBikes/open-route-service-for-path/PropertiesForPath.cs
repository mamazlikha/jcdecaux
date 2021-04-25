using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class PropertiesForPath
    {
        [JsonPropertyName("segments")]
        [DataMember]
        public List<Segment> Segments { get; set; }

        [JsonPropertyName("summary")]
        [DataMember]
        public Summary Summary { get; set; }

        [JsonPropertyName("way_points")]
        [DataMember]
        public List<int> WayPoints { get; set; }
    }

}
