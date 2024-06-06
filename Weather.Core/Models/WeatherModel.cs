namespace Weather.Core.Models
{
    public class WeatherResponseModel : Dictionary<string, CountryResponseModel>
    {

    }

    public class CountryResponseModel : Dictionary<string, CityResponseModel>
    {

    }
}