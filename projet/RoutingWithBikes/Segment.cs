using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class Segment
    {
        [JsonPropertyName("distance")]
        [DataMember]
        public double Distance { get; set; }

        [JsonPropertyName("duration")]
        [DataMember]
        public double Duration { get; set; }

        [JsonPropertyName("steps")]
        [DataMember]
        public List<Step> Steps { get; set; }
    }

}
