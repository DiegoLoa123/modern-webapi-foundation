using ProyPruebasApi.Application.Contracts;

namespace ProyPruebasApi.Application.Interfaces;

public interface IWeatherForecastService
{
    IReadOnlyCollection<WeatherForecastResponse> GetForecast(int days = 5);
}
