using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    public class Properties
    {
        [JsonPropertyName("id")]
        [DataMember]
        public string Id { get; set; }

        [JsonPropertyName("gid")]
        [DataMember]
        public string Gid { get; set; }

        [JsonPropertyName("layer")]
        [DataMember]
        public string Layer { get; set; }

        [JsonPropertyName("source")]
        [DataMember]
        public string Source { get; set; }

        [JsonPropertyName("source_id")]
        [DataMember]
        public string SourceId { get; set; }

        [JsonPropertyName("name")]
        [DataMember]
        public string Name { get; set; }

        [JsonPropertyName("housenumber")]
        [DataMember]
        public string Housenumber { get; set; }

        [JsonPropertyName("street")]
        [DataMember]
        public string Street { get; set; }

        [JsonPropertyName("postalcode")]
        [DataMember]
        public string Postalcode { get; set; }

        [JsonPropertyName("accuracy")]
        [DataMember]
        public string Accuracy { get; set; }

        [JsonPropertyName("country")]
        [DataMember]
        public string Country { get; set; }

        [JsonPropertyName("country_gid")]
        [DataMember]
        public string CountryGid { get; set; }

        [JsonPropertyName("country_a")]
        [DataMember]
        public string CountryA { get; set; }

        [JsonPropertyName("macroregion")]
        [DataMember]
        public string Macroregion { get; set; }

        [JsonPropertyName("macroregion_gid")]
        [DataMember]
        public string MacroregionGid { get; set; }

        [JsonPropertyName("macroregion_a")]
        [DataMember]
        public string MacroregionA { get; set; }

        [JsonPropertyName("region")]
        [DataMember]
        public string Region { get; set; }

        [JsonPropertyName("region_gid")]
        [DataMember]
        public string RegionGid { get; set; }

        [JsonPropertyName("region_a")]
        [DataMember]
        public string RegionA { get; set; }

        [JsonPropertyName("macrocounty")]
        [DataMember]
        public string Macrocounty { get; set; }

        [JsonPropertyName("macrocounty_gid")]
        [DataMember]
        public string MacrocountyGid { get; set; }

        [JsonPropertyName("county")]
        [DataMember]
        public string County { get; set; }

        [JsonPropertyName("county_gid")]
        [DataMember]
        public string CountyGid { get; set; }

        [JsonPropertyName("localadmin")]
        [DataMember]
        public string Localadmin { get; set; }

        [JsonPropertyName("localadmin_gid")]
        [DataMember]
        public string LocaladminGid { get; set; }

        [JsonPropertyName("locality")]
        [DataMember]
        public string Locality { get; set; }

        [JsonPropertyName("locality_gid")]
        [DataMember]
        public string LocalityGid { get; set; }

        [JsonPropertyName("continent")]
        [DataMember]
        public string Continent { get; set; }

        [JsonPropertyName("continent_gid")]
        [DataMember]
        public string ContinentGid { get; set; }

        [JsonPropertyName("label")]
        [DataMember]
        public string Label { get; set; }
    }
}
