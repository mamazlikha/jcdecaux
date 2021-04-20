using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{

    public class OpenRouteServiceApiForPath
    {
        [JsonPropertyName("type")]
        [DataMember]
        public string Type { get; set; }

        [JsonPropertyName("features")]
        [DataMember]
        public List<FeatureForPath> Features { get; set; }

        [JsonPropertyName("bbox")]
        [DataMember]
        public List<double> Bbox { get; set; }

        [JsonPropertyName("metadata")]
        [DataMember]
        public Metadata Metadata { get; set; }
    }
}
