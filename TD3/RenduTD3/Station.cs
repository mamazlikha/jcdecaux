using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenduTD3
{
    class Station
    {
        public int number { get; set; }
        public string contract_name { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Position position { get; set; }
        public bool banking { get; set; }
        public bool bonus { get; set; }
        public int bike_stands { get; set; }
        public int available_bike_stands { get; set; }
        public int available_bikes { get; set; }
        public string status { get; set; }
        public int last_update { get; set; }


        public override string ToString()
        {
            return "number = " + number + ", contract_name = " + contract_name + ", name = " + name + ", address" + address + ", position = {" + position.ToString() +
                "}, banking = " + banking + ", bonus = " + bonus + ", bike_stands = " + bike_stands + ", available_bike_stands = " + available_bike_stands +
                ", available_bikes = " + available_bikes + ",status = " + status + ", last_update = " + last_update;

        }
    }
}
