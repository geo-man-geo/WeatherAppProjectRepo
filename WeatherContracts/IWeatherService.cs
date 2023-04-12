using WeatherModels;
namespace WeatherContracts
{
    public interface IWeatherService
    {
        public List<WeatherModel> GetWeatherDetails();
        public WeatherModel? GetWeatherCity(string CityCode);
    }
}