using System.Text.Json;
using Weather.Core.Models;

namespace Weather.Core.Services
{
    public class WeatherRepository
    {
        private WeatherResponseModel _data = new WeatherResponseModel();

        public WeatherRepository()
        {
            PopulateData();
        }

        private void PopulateData()
        {
            var weatherData = File.ReadAllText("weatherData.json");
            _data = JsonSerializer.Deserialize<WeatherResponseModel>(weatherData) ?? new WeatherResponseModel();
        }

        public WeatherResponseModel FindAll()
        {
            return _data;
        }
    }

}
