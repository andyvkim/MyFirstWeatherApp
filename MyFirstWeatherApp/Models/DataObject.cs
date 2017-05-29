using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWeatherApp.Models
{
    public class DataObject
    {
        public int time { get; set; }
        public double precipIntensity { get; set;}
        public double precipProbability { get; set; }
    }
}