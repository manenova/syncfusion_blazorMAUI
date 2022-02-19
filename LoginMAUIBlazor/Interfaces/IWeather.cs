using LoginMAUIBlazor.Models;

namespace LoginMAUIBlazor.Interfaces
{
    internal interface IWeather
    {
        Task<List<Weather>> GetWeathers(String token);
    }
}
