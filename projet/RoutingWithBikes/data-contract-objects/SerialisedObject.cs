using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RoutingWithBikes
{
    [DataContract]
    public class SerialisedObject
    {
        [DataMember]
        public List<Position> positions { get; set; }

        [DataMember]
        public List<OpenRouteServiceApiForPath> AllPath { get; set; }

        public SerialisedObject (List<Position> positions, List<OpenRouteServiceApiForPath> AllPaths)
        {
            this.positions = positions;

            this.AllPath = AllPaths;
        }


    }
}
