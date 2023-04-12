using WeatherContracts;
using WeatherModels;

namespace WeatherServices
{
    public class WeatherService : IWeatherService
    {
        private List<WeatherModel>? _cityWeather;
        private string? _cityCode;

        public WeatherService()
        {
            _cityWeather = new List<WeatherModel>()
            {
                new WeatherModel() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 },
                new WeatherModel() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 },
                new WeatherModel() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 }
            };
        }
        public List<WeatherModel> GetWeatherDetails()
        {
            return _cityWeather;
        }
        public WeatherModel? GetWeatherCity(string CityCode)
        {
            _cityCode= CityCode;
            WeatherModel? cityList = _cityWeather?.FirstOrDefault(city => city.CityUniqueCode == _cityCode);
            return cityList;
        }

   
    }
}
