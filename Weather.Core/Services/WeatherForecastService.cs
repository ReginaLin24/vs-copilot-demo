using Weather.Core.Models;

namespace Weather.Core.Services
{
    public class WeatherForecastService
    {
        private readonly WeatherRepository _weatherRepository;
        public WeatherForecastService(WeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public WeatherResponseModel FindAllWeatherForecast()
        {
            return _weatherRepository.FindAll();
        }

        public CountryResponseModel? FindWeatherForecastByCountryName(string countryName)
        {
            var allData = _weatherRepository.FindAll();
            if (allData != null)
            {
                return allData[countryName];
            }
            return null;
        }
    }
}
