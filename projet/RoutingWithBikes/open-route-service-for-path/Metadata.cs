using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class Metadata
    {
        [JsonPropertyName("attribution")]
        [DataMember]
        public string Attribution { get; set; }

        [JsonPropertyName("service")]
        [DataMember]
        public string Service { get; set; }

        [JsonPropertyName("timestamp")]
        [DataMember]
        public long Timestamp { get; set; }

        [JsonPropertyName("query")]
        [DataMember]
        public QueryForPath Query { get; set; }

        [JsonPropertyName("engine")]
        [DataMember]
        public EngineForPath Engine { get; set; }
    }
}
