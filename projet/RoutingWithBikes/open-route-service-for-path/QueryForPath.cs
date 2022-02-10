using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class QueryForPath
    {
        [JsonPropertyName("coordinates")]
        [DataMember]
        public List<List<double>> Coordinates { get; set; }

        [JsonPropertyName("profile")]
        [DataMember]
        public string Profile { get; set; }

        [JsonPropertyName("format")]
        [DataMember]
        public string Format { get; set; }
    }

}
