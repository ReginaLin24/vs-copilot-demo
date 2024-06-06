namespace Weather.Core.Models
{
    public class CityResponseModel
    {
        public TemperatureResponseModel? Spring { get; set; }
        public TemperatureResponseModel? Summer { get; set; }
        public TemperatureResponseModel? Autumn { get; set; }
        public TemperatureResponseModel? Winter { get; set; }
    }
}
