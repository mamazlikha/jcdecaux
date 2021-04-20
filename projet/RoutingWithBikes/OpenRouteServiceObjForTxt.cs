using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<RoutingWithBikes>(myJsonResponse);
    
    public class OpenRouteServiceObjForTxt
    {
        [JsonPropertyName("geocoding")]
        [DataMember]
        public Geocoding Geocoding { get; set; }

        [JsonPropertyName("type")]
        [DataMember]
        public string Type { get; set; }

        [JsonPropertyName("features")]
        [DataMember]
        public List<Feature> Features { get; set; }

        [JsonPropertyName("bbox")]
        [DataMember]
        public List<double> Bbox { get; set; }
    }

}