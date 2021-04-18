using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{

    [DataContract]
    public class Station
    {

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("contractName")]
        [DataMember]
        public string ContractName { get; set; }

        [JsonPropertyName("name")]
        [DataMember]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        [DataMember]
        public string Address { get; set; }

        [JsonPropertyName("position")]
        [DataMember]
        public Position Position { get; set; }

        [JsonPropertyName("banking")]
        [DataMember]
        public bool Banking { get; set; }

        [JsonPropertyName("bonus")]
        [DataMember]
        public bool Bonus { get; set; }

        [JsonPropertyName("status")]
        [DataMember]
        public string Status { get; set; }

        [JsonPropertyName("lastUpdate")]
        [DataMember]
        public DateTime? LastUpdate { get; set; }

        [JsonPropertyName("connected")]
        [DataMember]
        public bool Connected { get; set; }

        [JsonPropertyName("overflow")]
        [DataMember]
        public bool Overflow { get; set; }

        [JsonPropertyName("shape")]
        [DataMember]
        public object Shape { get; set; }

        [JsonPropertyName("totalStands")]
        [DataMember]
        public TotalStands TotalStands { get; set; }

        [JsonPropertyName("mainStands")]
        [DataMember]
        public MainStands MainStands { get; set; }

        [JsonPropertyName("overflowStands")]
        [DataMember]
        public object OverflowStands { get; set; }

        public override string ToString()
        {
            return this.ContractName+", "+ this.Name + ", " + this.Number + "," + this.Address+", "+this.Position;
        }

    }
}
