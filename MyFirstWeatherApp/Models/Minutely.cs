using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWeatherApp.Models
{
    public class Minutely
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<DataFields> data { get; set; }
    }
}