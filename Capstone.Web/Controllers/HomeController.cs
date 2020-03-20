using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        IPark dao;
        IWeather WeatherDao;

        public HomeController(IPark dao, IWeather weatherDao)
        {
            this.dao = dao;
            this.WeatherDao = weatherDao;
        }

        public IActionResult Index(HomeList homeList)
        {
            var newList = dao.GetAllParks();
            homeList.parkList = newList.ToList();

            return View(homeList);
        }

        public IActionResult Detail(string id, string FahOrCalc)
        {
            WeatherList weatherList = new WeatherList();
            weatherList.park = dao.ParkDetail(id);
            weatherList.weatherList = WeatherDao.GetWeather(id);
            weatherList.FahOrCalc = GetTempChoice();
            

            return View(weatherList);
        }
       
        public IActionResult TempChoice(string FahOrCalc, string parkCode)
        {
            Weather weather = new Weather();
            weather.FahOrCalc = FahOrCalc;
            HttpContext.Session.SetString("FahOrCalc", FahOrCalc);

            return RedirectToAction("Detail", new{id = parkCode, FahOrCalc = weather.FahOrCalc });

        }

        private string GetTempChoice()
        {
            string tempChoice = HttpContext.Session.GetString("FahOrCalc");
            return tempChoice;
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
