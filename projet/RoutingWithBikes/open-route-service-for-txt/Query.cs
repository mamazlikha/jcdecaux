using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class Query
    {
        [JsonPropertyName("text")]
        [DataMember]
        public string Text { get; set; }

        [JsonPropertyName("parser")]
        [DataMember]
        public string Parser { get; set; }

        [JsonPropertyName("parsed_text")]
        [DataMember]
        public ParsedText ParsedText { get; set; }

        [JsonPropertyName("size")]
        [DataMember]
        public int Size { get; set; }

        [JsonPropertyName("private")]
        [DataMember]
        public bool Private { get; set; }

        [JsonPropertyName("lang")]
        [DataMember]
        public Lang Lang { get; set; }
    }
}
