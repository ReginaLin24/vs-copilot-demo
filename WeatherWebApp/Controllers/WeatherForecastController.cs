using Microsoft.AspNetCore.Mvc;
using Weather.Core.Models;
using Weather.Core.Services;

namespace WeatherWebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly WeatherForecastService _weatherService;

    public WeatherForecastController(WeatherForecastService weatherService)
    {

        _weatherService = weatherService;
    }

    [HttpGet(Name = "FindWeatherForecast")]
    public ActionResult<WeatherResponseModel> FindWeatherForecast()
    {
        var allData = _weatherService.FindAllWeatherForecast();

        if (allData == null)
            return NotFound("No data found.");

        return Ok(allData);
    }

    [HttpGet("{countryName}", Name = "FindByCountryName")]
    public ActionResult<CountryResponseModel> FindByCountryName(string countryName)
    {
        var result = _weatherService.FindWeatherForecastByCountryName(countryName);

        if (result == null)
            return NotFound($"No data found for country: {countryName}");

        return Ok(result);

    }

}
