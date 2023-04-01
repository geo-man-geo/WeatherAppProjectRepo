using Microsoft.AspNetCore.Mvc;
using WeatherAppProject.Models;

namespace WeatherAppProject.Controllers
{
    public class WeatherController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cityWeather = new List<CityWeather>() { 
                new CityWeather() {CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33},
                new CityWeather() {CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
                new CityWeather() {CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
            };
            ViewBag.cityWeather = cityWeather;
            return View();
        }

        [Route("weather/{cityCode}")]
        public IActionResult Weather(string cityCode)
        {
            List<CityWeather> cityWeather = new List<CityWeather>() {
                new CityWeather() {CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33},
                new CityWeather() {CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
                new CityWeather() {CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
            };

            var cityList = cityWeather.Where(city => city.CityUniqueCode == cityCode).ToList();
            ViewBag.cityList = cityList;
            return View(cityList);
        }
    }
}
