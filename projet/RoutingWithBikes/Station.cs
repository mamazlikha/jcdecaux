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
        [DataMember]
        public long Number { get; set; }

        [JsonPropertyName("contract_name")]
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

        [JsonPropertyName("bike_stands")]
        [DataMember]
        public long BikeStands { get; set; }

        [JsonPropertyName("available_bike_stands")]
        [DataMember]
        public long AvailableBikeStands { get; set; }

        [JsonPropertyName("available_bikes")]
        [DataMember]
        public long AvailableBikes { get; set; }

        [JsonPropertyName("status")]
        [DataMember]
        public string Status { get; set; }

        [JsonPropertyName("last_update")]
        [DataMember]
        public long? LastUpdate { get; set; }

        public override string ToString()
        {
            if (LastUpdate != null)
            {
                return "{\"Address\":\"" + Address + "\",\"AvailableBikeStands\":" + AvailableBikeStands +
                    ",\"AvailableBikes\":" + AvailableBikes + ",\"Banking\":" + Banking +
                    ",\"BikeStands\":" + BikeStands + ",\"Bonus\":" + Bonus + ",\"ContractName\":\"" + ContractName +
                    "\",\"LastUpdate\":" + LastUpdate + ",\"Name\":\"" + Name + "\",\"Number\":" + Number +
                    ",\"Position\":" + Position.ToString() + ",\"Status\":\"" + Status + "\"}";
            }
            else
            {
                return "{\"Address\":\"" + Address + "\",\"AvailableBikeStands\":" + AvailableBikeStands +
                    ",\"AvailableBikes\":" + AvailableBikes + ",\"Banking\":" + Banking +
                    ",\"BikeStands\":" + BikeStands + ",\"Bonus\":" + Bonus + ",\"ContractName\":\"" + ContractName +
                   ",\"Name\":\"" + Name + "\",\"Number\":" + Number +
                    ",\"Position\":" + Position.ToString() + ",\"Status\":\"" + Status + "\"}";
            }
        }
    }
}
