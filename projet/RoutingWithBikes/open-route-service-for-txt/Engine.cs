using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class Engine
    {
        [JsonPropertyName("name")]
        [DataMember]
        public string Name { get; set; }

        [JsonPropertyName("author")]
        [DataMember]
        public string Author { get; set; }

        [JsonPropertyName("version")]
        [DataMember]
        public string Version { get; set; }
    }
}
