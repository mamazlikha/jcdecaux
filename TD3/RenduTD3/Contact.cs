using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RenduTD3
{
    class Contact
    {
        public String name { get; set; }
        public String commercial_name { get; set; }
        public String[] cities { get; set; }
        public String country_code { get; set; }


       public Contact() { }

        /*public Contact(String name, String com_name, Country_Code cc, String[] cities)
        {
            this.name = name;
            this.commercial_name = com_name;
            this.country_code = cc;
            this.cities = cities;
        }
        public Contact(String name)
        {
            this.name = name;
        }*/

        public override string ToString()
        {
            return "{\"name\":\"" + this.name + "\",\"commercial_name\":\""+this.commercial_name+ "\",\"cities\":["+this.cities+ "],\"country_code\":\""+this.country_code+"\"}";
        }



    }
}
