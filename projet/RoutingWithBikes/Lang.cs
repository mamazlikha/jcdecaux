using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class Lang
    {
        [JsonPropertyName("name")]
        [DataMember]
        public string Name { get; set; }

        [JsonPropertyName("iso6391")]
        [DataMember]
        public string Iso6391 { get; set; }

        [JsonPropertyName("iso6393")]
        [DataMember]
        public string Iso6393 { get; set; }

        [JsonPropertyName("defaulted")]
        [DataMember]
        public bool Defaulted { get; set; }
    }
}
