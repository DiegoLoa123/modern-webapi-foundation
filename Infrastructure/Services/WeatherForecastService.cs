using ProyPruebasApi.Application.Contracts;
using ProyPruebasApi.Application.Interfaces;

namespace ProyPruebasApi.Infrastructure.Services;

public sealed class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public IReadOnlyCollection<WeatherForecastResponse> GetForecast(int days = 5) =>
        Enumerable.Range(1, days)
            .Select(index => new WeatherForecastResponse(
                DateOnly.FromDateTime(DateTime.UtcNow.AddDays(index)),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]))
            .ToArray();
}
