using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWeatherApp.Models
{
    public class DarkSkyObject
    {
        public double latitude { get; set; }
        public double longtitude { get; set; }
        public string timezone { get; set; }
        public double offset { get; set; }
        public DataFields currently { get; set; }
        public Minutely minutely { get; set; }
        public Hourly hourly { get; set; }
        public Daily daily { get; set; }






    }
    }
