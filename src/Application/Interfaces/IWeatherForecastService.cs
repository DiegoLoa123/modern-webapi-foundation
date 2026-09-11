using ProyPruebasApi.src.Application.Contracts;

namespace ProyPruebasApi.src.Application.Interfaces;

public interface IWeatherForecastService
{
    IReadOnlyCollection<WeatherForecastResponse> GetForecast(int days = 5);
}
