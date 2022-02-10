using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class MainStands
    {
        [JsonPropertyName("availabilities")]
        [DataMember]
        public Availabilities Availabilities { get; set; }

        [JsonPropertyName("capacity")]
        [DataMember]
        public int Capacity { get; set; }
    }
}
