using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    public class Station
    {
        public string address { get; set; }
        public string status { get; set; }
        public int available_bikes { get; set; }
        public string name { get; set; }

        public Station(string address, string status, int available_bikes, string name)
        {
            this.address = address;
            this.status = status;
            this.available_bikes = available_bikes;
            this.name = name;
        }
    }
}
