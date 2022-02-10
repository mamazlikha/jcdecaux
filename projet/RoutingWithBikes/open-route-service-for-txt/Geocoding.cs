﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class Geocoding
    {
        [JsonPropertyName("version")]
        [DataMember]
        public string Version { get; set; }

        [JsonPropertyName("attribution")]
        [DataMember]
        public string Attribution { get; set; }

        [JsonPropertyName("query")]
        [DataMember]
        public Query Query { get; set; }

        [JsonPropertyName("engine")]
        [DataMember]
        public Engine Engine { get; set; }

        [JsonPropertyName("timestamp")]
        [DataMember]
        public long Timestamp { get; set; }
    }
}
