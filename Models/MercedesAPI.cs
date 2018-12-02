using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChargeMate.Models
{
    public class MercedesAPI
    {
        public Longitude longitude;
        public Latitude latitude;
        public Heading heading;
    }
    public class Stateofcharge
    {
        public int value { get; set; }
        public string retrievalstatus { get; set; }
        public int timestamp { get; set; }
        public string unit { get; set; }
    }

    public class StateofchargeRootObject
    {
        public Stateofcharge stateofcharge { get; set; }
    }
}