using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class Step
    {
        [JsonPropertyName("distance")]
        [DataMember]
        public double Distance { get; set; }

        [JsonPropertyName("duration")]
        [DataMember]
        public double Duration { get; set; }

        [JsonPropertyName("type")]
        [DataMember]
        public int Type { get; set; }

        [JsonPropertyName("instruction")]
        [DataMember]
        public string Instruction { get; set; }

        [JsonPropertyName("name")]
        [DataMember]
        public string Name { get; set; }

        [JsonPropertyName("way_points")]
        [DataMember]
        public List<int> WayPoints { get; set; }
    }
}
