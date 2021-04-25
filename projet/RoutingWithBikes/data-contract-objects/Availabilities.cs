using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class Availabilities
    {
        [JsonPropertyName("bikes")]
        [DataMember]
        public int Bikes { get; set; }

        [JsonPropertyName("stands")]
        [DataMember]
        public int Stands { get; set; }

        [JsonPropertyName("mechanicalBikes")]
        [DataMember]
        public int MechanicalBikes { get; set; }

        [JsonPropertyName("electricalBikes")]
        [DataMember]
        public int ElectricalBikes { get; set; }

        [JsonPropertyName("electricalInternalBatteryBikes")]
        [DataMember]
        public int ElectricalInternalBatteryBikes { get; set; }

        [JsonPropertyName("electricalRemovableBatteryBikes")]
        [DataMember]
        public int ElectricalRemovableBatteryBikes { get; set; }
    }
}
