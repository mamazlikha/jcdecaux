using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class GeometryForPath
    {
        [JsonPropertyName("coordinates")]
        [DataMember]
        public List<List<double>> coordinates { get; set; }

        [JsonPropertyName("type")]
        [DataMember]
        public string type { get; set; }
    }
}
