using Microsoft.AspNetCore.Mvc;
using WeatherContracts;
using WeatherServices;
using WeatherModels;

namespace WeatherAppProject.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public WeatherController(IWeatherService weatherService, IServiceScopeFactory serviceScopeFactory)
        {
            _weatherService = weatherService;
            _serviceScopeFactory = serviceScopeFactory;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<WeatherModel>? weatherDetails;
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                IWeatherService? weatherServiceScoped = scope.ServiceProvider.GetService<IWeatherService>();
                weatherDetails = weatherServiceScoped?.GetWeatherDetails();
            }
            return View((IEnumerable<WeatherModel>?)weatherDetails);
        }

        [Route("weather/{cityCode}")]
        public IActionResult Weather(string cityCode)
        {
            string cityUniqueCode = cityCode;
            WeatherModel? city;
            using(IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                IWeatherService? weatherServiceScoppedcity = scope.ServiceProvider.GetService<IWeatherService>();
                city = weatherServiceScoppedcity?.GetWeatherCity(cityUniqueCode);
            }
            return View((WeatherModel?)city);

        }
    }
}
