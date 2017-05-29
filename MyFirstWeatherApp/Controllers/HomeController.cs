using MyFirstWeatherApp.Models;
using MyFirstWeatherApp.Views.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFirstWeatherApp.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<string> GetForecast(string longitude, string latitude)
        {
            DarkSkyService darkSkyService = new DarkSkyService("bb113d05c9be235ad2edae74a9ad6075");
            string rtn;

            var temp = await darkSkyService.GetForecast(double.Parse(latitude), double.Parse(longitude));

            rtn = JsonConvert.SerializeObject(temp);
            return rtn;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}