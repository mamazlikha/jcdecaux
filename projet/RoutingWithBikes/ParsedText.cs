using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class ParsedText
    {
        [JsonPropertyName("subject")]
        [DataMember]
        public string Subject { get; set; }

        [JsonPropertyName("housenumber")]
        [DataMember]
        public string Housenumber { get; set; }

        [JsonPropertyName("street")]
        [DataMember]
        public string Street { get; set; }

        [JsonPropertyName("postcode")]
        [DataMember]
        public string Postcode { get; set; }

        [JsonPropertyName("locality")]
        [DataMember]
        public string Locality { get; set; }

        [JsonPropertyName("admin")]
        [DataMember]
        public string Admin { get; set; }
    }
}
