using Microsoft.AspNetCore.Mvc;

namespace WeatherWebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public class Temperature
    {
        public int high { get; set; }
        public int low { get; set; }
    }

    public class WeatherData : Dictionary<string, Dictionary<string, Dictionary<string, Temperature>>> { }


    public WeatherForecastController()
    {
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public WeatherData Get()
    {
        var weatherData = System.IO.File.ReadAllText("weatherData.json");
        var weatherForecasts = System.Text.Json.JsonSerializer.Deserialize<WeatherData>(weatherData);
        return weatherForecasts;
    }

    // write a new Get function that returns the city name based on the country name and ensure the city name returned is in Capital
    [HttpGet("{countryName}", Name = "GetCityName")]
    public IActionResult Get(string countryName)
    {
        if (string.IsNullOrEmpty(countryName))
        {
            return BadRequest("Country name must not be null or empty.");
        }
        string weatherData;
        try
        {
            weatherData = System.IO.File.ReadAllText("weatherData.json");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while reading the file: {ex.Message}");
        }

        WeatherData weatherForecasts;
        try
        {
            weatherForecasts = System.Text.Json.JsonSerializer.Deserialize<WeatherData>(weatherData);
        }
        catch (System.Text.Json.JsonException ex)
        {
            return StatusCode(500, $"An error occurred while deserializing the JSON data: {ex.Message}");
        }

        if (!weatherForecasts.ContainsKey(countryName))
        {
            return NotFound($"No data found for country: {countryName}");
        }

        var city = weatherForecasts[countryName].Keys.First();
        return Ok(city.ToUpper());
    }

}
