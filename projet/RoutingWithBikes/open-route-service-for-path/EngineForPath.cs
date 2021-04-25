using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class EngineForPath
    {
        [JsonPropertyName("version")]
        [DataMember]
        public string Version { get; set; }

        [JsonPropertyName("build_date")]
        [DataMember]
        public DateTime BuildDate { get; set; }

        [JsonPropertyName("graph_date")]
        [DataMember]
        public DateTime GraphDate { get; set; }
    }


}
