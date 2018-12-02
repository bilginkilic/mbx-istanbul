using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChargeMate.Models
{
    public class Longitude
    {
        public double value { get; set; }
        public string retrievalstatus { get; set; }
        public int timestamp { get; set; }
    }

    public class Latitude
    {
        public double value { get; set; }
        public string retrievalstatus { get; set; }
        public int timestamp { get; set; }
    }

    public class Heading
    {
        public double value { get; set; }
        public string retrievalstatus { get; set; }
        public int timestamp { get; set; }
    }
}